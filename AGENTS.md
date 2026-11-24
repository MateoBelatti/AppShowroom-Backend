# back-AppShow — API ASP.NET Core

Repo: `AppShowroom-Backend` · rama principal `master` · trabajo en `dev`. Contexto general: `../AGENTS.md`.

## Solución (`appShowroom.slnx`)

| Proyecto | Contenido | Depende de |
|---|---|---|
| `Api` | `Program.cs` (DI, JWT, CORS, Swagger), `Controllers/`, `Middlewares/ErrorHandlerMiddleware.cs` | Services, Repository, biblioteca |
| `Services` | `Services/Services/<dominio>/I<X>Service.cs` + `<X>Service.cs` (lógica de negocio, auth/JWT/Google) | Repository, biblioteca |
| `Repository` | `Repository/<dominio>/I<X>Repository.cs` + `<X>Repository.cs`, `CanelaContext.cs`, `Migrations/` (único lugar que usa el DbContext) | biblioteca |
| `biblioteca` | `clases/` (entidades), `dtos/<dominio>/` (`XDto`, `XCreateDto`, `XUpdateDto`), `mappers/` (AutoMapper `Profile`), `types/` (enums `Rol`, `typeProducto`), `Errors/` | — |
| `Tests` | xUnit + Moq: tests de mappers y services, sin base de datos | Services, Repository, biblioteca |

**Regla de capas:** Controller → Service → Repository → DbContext. Un controller nunca toca el `DbContext`; un service nunca devuelve entidades al controller, devuelve DTOs. La identidad del request se expone a Services con `Services.ICurrentUser` (implementado en `Api/Identity/CurrentUser.cs`): los controllers no pasan claims ni ids del JWT a los services.

## Convenciones observadas

- Rutas: `api/[controller]`; las clases de controller están en minúscula (`authController` → `/api/auth`). Dominios: `usuario`, `producto`, `categoria`, `carrito`, `detalleCarrito`, `auth`.
- Errores de negocio: `throw new AppException(mensaje, statusCode, "Clase.metodo")` (namespace `biblioteca.Errors`). El middleware los serializa a JSON.
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

`Api/appsettings.json` y `Api/appsettings.Development.json` están en `.gitignore` y la configuración va por variables de entorno (`__`) o por user-secrets en local. El 2026-11-23 se les hizo `git rm --cached`: siguen en el disco local pero ya no están en el índice (ver problema 1). El project ID para user-secrets ya está en `Api/Api.csproj`:

```bash
dotnet user-secrets --project Api set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=appshow;Username=postgres;Password=dev"
dotnet user-secrets --project Api set "Jwt:SecretKey" "clave-local-de-al-menos-32-caracteres-xxxxxxxx"
```

Plantilla para un clone nuevo: crear `Api/appsettings.example.json` con los mismos bloques (`Logging`, `AllowedHosts`, `ConnectionStrings:DefaultConnection`, `Google:ClientId`, `Jwt:*`) pero con valores de ejemplo, y copiarlo a `appsettings.json` / `appsettings.Development.json`. La plantilla **no se ignora** (excepción en `.gitignore`). En producción (Railway) los valores van siempre como variables de entorno: `ConnectionStrings__DefaultConnection`, `Jwt__SecretKey`, `Jwt__Issuer`, `Jwt__Audience`, `Jwt__ExpirationHours`, `Google__ClientId`. `.dockerignore` excluye los `appsettings*.json` para que no queden dentro de la imagen.

## Comandos

```bash
dotnet build appShowroom.slnx
dotnet run --project Api            # aplica migraciones al arrancar: solo con la DB local
dotnet test                         # 8 tests, no necesita DB
```
CI: `.github/workflows/ci.yml` corre `restore` + `build --configuration Release` + `test` en push y PR a `dev`/`master`.
Migraciones: usá la skill `migracion-ef`, pero con `--project back-AppShow/Repository` (antes era `biblioteca`). `CanelaContext` y `Migrations/` viven en `Repository/`, aunque conservan el namespace `biblioteca` / `biblioteca.Migrations` para no editar a mano los archivos generados. **`dotnet ef database update` está denegado** en `opencode.json`.

## Problemas conocidos (verificados leyendo el código)

1. **Secretos en git (parcialmente resuelto 2026-11-23):** se quitaron del índice con `git rm --cached` y siguen en el disco local; no se reescribió el historial. Falta rotar cualquier credencial que haya quedado en él. No se leyó el contenido de esos archivos (acceso bloqueado).
2. **Autorización ya corregida (2026-11-23):** `usuarioController`, `carritoController` y `detalleCarritoController` tienen `[Authorize]`; el registro sigue con `[AllowAnonymous]`; los servicios validan dueño con `ValidarAcceso` / `ValidarPropietario` usando `ICurrentUser`. Pendiente: centralizar esa validación (hoy está repetida en tres services).
3. **Claim de rol ya corregido:** `Program.cs` define `RoleClaimType = "rol"`. Falta verificarlo con un login de admin real.
4. **Fechas ya corregidas:** `CarritoService` usa `DateTime.UtcNow` y setea `FechaCreacion` / `UltimaVez` al crear.
5. **`Database.Migrate()` al arrancar** (`Program.cs`): aceptable en desarrollo, riesgoso en producción.
6. **Tests y CI ya agregados (2026-11-23):** proyecto `Tests` (xUnit + Moq, 8 tests) y `.github/workflows/ci.yml` (build + test en push/PR a `dev`/`master`). Faltan tests de integración con DB.
7. **Dependencias actualizadas (2026-11-23):** AutoMapper 16.3.0 y Microsoft.OpenApi 2.7.5 (referencia directa en `Api.csproj` para forzar la versión transitiva de Swashbuckle). `dotnet build` da 0 warnings y `dotnet list package --vulnerable` no reporta vulnerabilidades.
8. **AutoMapper 16 requiere license key** (`cfg.LicenseKey`) según la guía de upgrade de 15.0; `Program.cs` no la configura. No verificado en runtime: revisar al arrancar la API con DB local.

## Pendiente de producto

Entidades `Pedido` / `DetallePedido`, checkout y endpoints de métricas: ver `../docs/PLAN-METRICAS.md`.
