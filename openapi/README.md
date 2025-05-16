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