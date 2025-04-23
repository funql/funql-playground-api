Returns a list of minifigures.

<details>
<summary>Details</summary>

## Field functions

| Field  | Type     | Function | Example       |
|--------|----------|----------|---------------|
| `name` | `string` | `lower`  | `lower(name)` |
|        |          | `upper`  | `upper(name)` |

## Sort functions

| Field          | Type        | Direction | Example                    |
|----------------|-------------|-----------|----------------------------|
| `id`           | `uuid`      | `asc`     | `?sort=asc(id)`            |
|                |             | `desc`    | `?sort=desc(id)`           |
| `name`         | `string`    | `asc`     | `?sort=asc(name)`          |
|                |             | `desc`    | `?sort=desc(name)`         |

## Filter functions

| Field  | Type     | Operator | Example                                                  |
|--------|----------|----------|----------------------------------------------------------|
| `id`   | `uuid`   | `eq`     | `?filter=eq(id,"533d3fe3-bccc-405a-9904-4f516e892856")`  |
|        |          | `neq`    | `?filter=neq(id,"533d3fe3-bccc-405a-9904-4f516e892856")` |
| `name` | `string` | `eq`     | `?filter=eq(name,"Millennium Falcon")`                   |
|        |          | `neq`    | `?filter=neq(name,"Millennium Falcon")`                  |
|        |          | `gt`     | `?filter=gt(name,"Millennium Falcon")`                   |
|        |          | `gte`    | `?filter=gte(name,"Millennium Falcon")`                  |
|        |          | `lt`     | `?filter=lt(name,"Millennium Falcon")`                   |
|        |          | `lte`    | `?filter=lte(name,"Millennium Falcon")`                  |
|        |          | `has`    | `?filter=has(name,"Millennium")`                         |
|        |          | `stw`    | `?filter=stw(name,"Millennium")`                         |
|        |          | `enw`    | `?filter=enw(name,"Falcon")`                             |
|        |          | `reg`    | `?filter=reg(name,"^[a-zA-Z0-9 ]+$")`                    |

</details>