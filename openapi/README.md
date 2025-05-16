# FunQL Playground API specification

[![License: CC BY-SA 4.0](https://img.shields.io/badge/license-CC%20BY--SA%204.0-orange.svg)](https://github.com/funql/funql-playground-api/blob/main/openapi/LICENSE)

This folder contains the OpenAPI Specification (OAS) for the [FunQL Playground API](https://api.play.funql.io/). The API
allows developers to experiment with [FunQL](https://funql.io/) — the Functional Query Language — through a simple REST
interface.

## Conventions

- OpenAPI 3.1 is used as the base version.
- The API specification is organized as a modular file structure for reusability and clarity.
- `$ref` is used extensively to reference reusable components (parameters, schemas, responses, etc.).
- Markdown files use [CommonMark syntax](https://spec.commonmark.org/).

### Basic structure

To improve maintainability of the API specification, we split the OpenAPI definitions into smaller, reusable parts.

We use [Redocly CLI](https://github.com/Redocly/redocly-cli) to bundle these parts into a single OpenAPI file and to
generate API reference documentation.

```
<version>/                             # Versioned folder for the API specification (e.g., v1beta1)
├── _examples/                         # Reusable examples for parameters, request/response bodies, objects, and properties
├── _headers/                          # Reusable response headers
├── _parameters/                       # Reusable parameters
│   ├── cookie/                        # Cookie parameters
│   ├── header/                        # Header parameters
│   ├── path/                          # Path parameters
│   └── query/                         # Query parameters (e.g., filter, sort, limit)
├── _responses/                        # Reusable responses (e.g., 400 Bad Request)
├── _schemas/                          # Reusable schemas (data models)
├── _securitySchemes/                  # Reusable security schemes (e.g., OAuth 2, API keys)
├── <endpoint>/                        # Folder per endpoint group
│   ├── _parameters/                   # Endpoint-specific parameters
│   │   └── path/                      # Path parameters
│   ├── _paths/                        # Individual operations
│   │   ├── <endpoint>#description.md  # Markdown description for the operation
│   │   └── <endpoint>.yaml            # Path and method definitions
│   └── _schemas/                      # Endpoint-specific schemas
├── _headers.yaml                      # References all reusable headers
├── _parameters.yaml                   # References all reusable parameters
├── _responses.yaml                    # References all reusable responses
├── _schemas.yaml                      # References all reusable schemas
├── _securitySchemes.yaml              # References all reusable security schemes
├── info#description.md                # Markdown description for the top-level "info" section
└── openapi.yaml                       # Main entrypoint for Redocly CLI
```

### Naming conventions

We use consistent naming conventions for files and folders to keep the specification readable and maintainable.

#### Folder naming

- Use **kebab-case** for folder names, including endpoint groups (e.g., `lego-sets/`).
- Common folders for reusable components (like `_schemas`, `_parameters`) are prefixed with an underscore to indicate
  internal reuse.

#### File naming

Naming style is based on the component type:

| Type       | Convention             | Example            |
|------------|------------------------|--------------------|
| Headers    | Hyphenated-Pascal-Case | `Total-Count.yaml` |
| Parameters | camelCase              | `setId.yaml`       |
| Paths      | kebab-case             | `sets.yaml`        |
| Schemas    | PascalCase             | `Set.yaml`         |

#### Markdown files

Markdown files (`*.md`) provide rich descriptions in the generated API documentation. They are referenced using `$ref`
to populate specific fields such as `description`.

- The base filename must match the file that references it.
- The fragment (after `#`) indicates the target property.
- Place the Markdown file in the same folder as the referencing file.

For example, `sets#description.md` provides the `description` for the `/sets` path defined in `sets.yaml`.

#### File extensions

- Use `.yaml` (not `.yml`) for OpenAPI definition files.
- Use `.md` for Markdown description files.

#### Suffixes for path files

Use suffixes to distinguish parameterized paths:

- `{paramName}` in a path is expressed with a suffix in the file name.
- For example, `sets_{setId}.yaml` defines operations for `/sets/{setId}`.

This helps keep file names descriptive and unambiguous.

#### Example

```
<version>/                     #
├── _headers/                  #
│   └── Total-Count.yaml       # Header 'Total-Count'
├── _parameters/               #
│   └── query/                 #
│       └── skip.yaml          # Query parameter 'skip'
├── sets/                      #
│   ├── _parameters/           #
│   │   └── setId.yaml         # Path parameter 'setId'
│   ├── _paths/                #
│   │   ├── sets.yaml          # Operations for '/sets' path
│   │   └── sets_{setId}.yaml  # Operations for '/sets/{setId}' path
│   └── _schemas/              #
│       └── Set.yaml           # Data model 'Set'
```