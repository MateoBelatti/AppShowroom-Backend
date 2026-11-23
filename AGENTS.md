# back-AppShow — API ASP.NET Core

Repo: `AppShowroom-Backend` · rama principal `master` · trabajo en `dev`. Contexto general: `../AGENTS.md`.

## Solución (`appShowroom.slnx`)

| Proyecto | Contenido | Depende de |
|---|---|---|
| `Api` | `Program.cs` (DI, JWT, CORS, Swagger), `Controllers/`, `Middlewares/ErrorHandlerMiddleware.cs` | Services, Repository, biblioteca |
| `Services` | `Services/Services/<dominio>/I<X>Service.cs` + `<X>Service.cs` (lógica de negocio, auth/JWT/Google) | Repository, biblioteca |
| `Repository` | `Repository/<dominio>/I<X>Repository.cs` + `<X>Repository.cs` (único lugar que usa `CanelaContext`) | biblioteca |
| `biblioteca` | `clases/` (entidades), `dtos/<dominio>/` (`XDto`, `XCreateDto`, `XUpdateDto`), `mappers/` (AutoMapper `Profile`), `types/` (enums `Rol`, `typeProducto`), `Errors/`, `CanelaContext.cs`, `Migrations/` | — |

**Regla de capas:** Controller → Service → Repository → DbContext. Un controller nunca toca el `DbContext`; un service nunca devuelve entidades al controller, devuelve DTOs.

## Convenciones observadas

- Rutas: `api/[controller]`; las clases de controller están en minúscula (`authController` → `/api/auth`). Dominios: `usuario`, `producto`, `categoria`, `carrito`, `detalleCarrito`, `auth`.
- Errores de negocio: `throw new AppException(mensaje, statusCode, "Clase.metodo")` (namespace `Api.Errors`). El middleware los serializa a JSON.
- Autorización por rol: `[Authorize(Roles = "Admin")]`.
- Borrado de producto = borrado lógico (`Activo = false`). El registro de usuario fuerza `Rol.User`.
- Nombres: el código actual mezcla camelCase (`findById`, `create` en services) y PascalCase (`GetAll`, `FindByEmail` en repos). **No hagas renames masivos.** El código nuevo va en PascalCase.
- Todo se registra a mano en `Program.cs`: `AddScoped` de service y repository, y `cfg.AddProfile<...>()` del mapper.
- Fechas nuevas: `DateTime.UtcNow` (las columnas son `timestamp with time zone`).

## Entorno local (obligatorio)

```bash
docker run --name appshow-pg -e POSTGRES_PASSWORD=dev -e POSTGRES_DB=appshow -p 5432:5432 -d postgres:16

# variables de entorno de la sesión (no escribir en archivos versionados)
export ConnectionStrings__DefaultConnection="Host=localhost;Port=5432;Database=appshow;Username=postgres;Password=dev"
export Jwt__SecretKey="clave-local-de-al-menos-32-caracteres-xxxxxxxx"
export Jwt__Issuer="http://localhost" Jwt__Audience="http://localhost:5173" Jwt__ExpirationHours=24
export Google__ClientId="<client id de Google>"
```

### Secretos y configuración

`Api/appsettings.json` y `Api/appsettings.Development.json` **no se versionan** (están en `.gitignore`). Si por error aparecen en un clone nuevo, no están: la configuración va por variables de entorno (`__`) o por user-secrets en local. El project ID para user-secrets ya está en `Api/Api.csproj`:

```bash
dotnet user-secrets --project Api set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=appshow;Username=postgres;Password=dev"
dotnet user-secrets --project Api set "Jwt:SecretKey" "clave-local-de-al-menos-32-caracteres-xxxxxxxx"
```

Plantilla para un clone nuevo: crear `Api/appsettings.example.json` con los mismos bloques (`Logging`, `AllowedHosts`, `ConnectionStrings:DefaultConnection`, `Google:ClientId`, `Jwt:*`) pero con valores de ejemplo, y copiarlo a `appsettings.json` / `appsettings.Development.json`. La plantilla **no se ignora** (excepción en `.gitignore`). En producción (Railway) los valores van siempre como variables de entorno: `ConnectionStrings__DefaultConnection`, `Jwt__SecretKey`, `Jwt__Issuer`, `Jwt__Audience`, `Jwt__ExpirationHours`, `Google__ClientId`. `.dockerignore` excluye los `appsettings*.json` para que no queden dentro de la imagen.

## Comandos

```bash
dotnet build appShowroom.slnx
dotnet run --project Api            # aplica migraciones al arrancar: solo con la DB local
dotnet test                         # todavía no hay proyecto de tests
```
Migraciones: usá la skill `migracion-ef`. **`dotnet ef database update` está denegado** en `opencode.json`.

## Problemas conocidos (verificados leyendo el código)

1. **Secretos versionados:** `Api/appsettings.json` (connection string de Supabase con password) y `Api/appsettings.Development.json` (JWT secret) están en git y en el historial. Hay que rotarlos.
2. **Sin `[Authorize]`:** `usuarioController` completo (listar todos los usuarios, editar y borrar cualquiera), `carritoController` y `detalleCarritoController`. Hay que exigir token y validar que el `id` del JWT sea el dueño del recurso. `POST /api/usuario` (registro) tiene que seguir anónimo.
3. **Claim de rol:** el JWT usa el claim `rol` y `Program.cs` no define `RoleClaimType`. Probablemente `[Authorize(Roles = "Admin")]` no reconozca el rol: **verificar con un login de admin** y, si falla, agregar `RoleClaimType = "rol"` en `TokenValidationParameters`.
4. **`DateTime.Now`** en `CarritoService.update` (`UltimaVez`) con columna `timestamp with time zone`: Npgsql rechaza `Kind=Local`. Cambiar a `DateTime.UtcNow`. Además `FechaCreacion` del carrito no se setea al crear.
5. **`Database.Migrate()` al arrancar** (`Program.cs`): aceptable en desarrollo, riesgoso en producción.
6. **Sin tests** y sin CI.

## Pendiente de producto

Entidades `Pedido` / `DetallePedido`, checkout y endpoints de métricas: ver `../docs/PLAN-METRICAS.md`.
