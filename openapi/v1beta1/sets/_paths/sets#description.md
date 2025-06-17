Returns a list of sets.

<details>
<summary>Details</summary>

## Field functions

| Field                  | Type     | Function      | Example                       |
|------------------------|----------|---------------|-------------------------------|
| `name`                 | `string` | `lower`       | `lower(name)`                 |
|                        |          | `upper`       | `upper(name)`                 |
| `price`                | `double` | `floor`       | `floor(price)`                |
|                        |          | `ceiling`     | `ceiling(price)`              |
|                        |          | `round`       | `round(price)`                |
| `designer.name`        | `string` | `lower`       | `lower(designer.name)`        |
|                        |          | `upper`       | `upper(designer.name)`        |
| `launchTime`           | `double` | `year`        | `year(launchTime)`            |
|                        |          | `month`       | `month(launchTime)`           |
|                        |          | `day`         | `day(launchTime)`             |
|                        |          | `hour`        | `hour(launchTime)`            |
|                        |          | `minute`      | `minute(launchTime)`          |
|                        |          | `second`      | `second(launchTime)`          |
| `minifigures.$it.name` | `string` | `lower`       | `lower(minifigures.$it.name)` |
|                        |          | `upper`       | `upper(minifigures.$it.name)` |

## Sort functions

| Field           | Type        | Direction | Example                     |
|-----------------|-------------|-----------|-----------------------------|
| `id`            | `uuid`      | `asc`     | `?sort=asc(id)`             |
|                 |             | `desc`    | `?sort=desc(id)`            |
| `name`          | `string`    | `asc`     | `?sort=asc(name)`           |
|                 |             | `desc`    | `?sort=desc(name)`          |
| `setNumber`     | `integer`   | `asc`     | `?sort=asc(setNumber)`      |
|                 |             | `desc`    | `?sort=desc(setNumber)`     |
| `pieces`        | `integer`   | `asc`     | `?sort=asc(pieces)`         |
|                 |             | `desc`    | `?sort=desc(pieces)`        |
| `price`         | `double`    | `asc`     | `?sort=asc(price)`          |
|                 |             | `desc`    | `?sort=desc(price)`         |
| `designerId`    | `uuid`      | `asc`     | `?sort=asc(designerId)`     |
|                 |             | `desc`    | `?sort=desc(designerId)`    |
| `designer.id`   | `uuid`      | `asc`     | `?sort=asc(designer.id)`    |
|                 |             | `desc`    | `?sort=desc(designer.id)`   |
| `designer.name` | `string`    | `asc`     | `?sort=asc(designer.name)`  |
|                 |             | `desc`    | `?sort=desc(designer.name)` |
| `launchTime`    | `date-time` | `asc`     | `?sort=asc(launchTime)`     |
|                 |             | `desc`    | `?sort=desc(launchTime)`    |

## Filter functions

| Field                      | Type            | Operator | Example                                                                       |
|----------------------------|-----------------|----------|-------------------------------------------------------------------------------|
| `id`                       | `uuid`          | `eq`     | `?filter=eq(id,"533d3fe3-bccc-405a-9904-4f516e892856")`                       |
|                            |                 | `neq`    | `?filter=neq(id,"533d3fe3-bccc-405a-9904-4f516e892856")`                      |
| `name`                     | `string`        | `eq`     | `?filter=eq(name,"Millennium Falcon")`                                        |
|                            |                 | `neq`    | `?filter=neq(name,"Millennium Falcon")`                                       |
|                            |                 | `gt`     | `?filter=gt(name,"Millennium Falcon")`                                        |
|                            |                 | `gte`    | `?filter=gte(name,"Millennium Falcon")`                                       |
|                            |                 | `lt`     | `?filter=lt(name,"Millennium Falcon")`                                        |
|                            |                 | `lte`    | `?filter=lte(name,"Millennium Falcon")`                                       |
|                            |                 | `has`    | `?filter=has(name,"Millennium")`                                              |
|                            |                 | `stw`    | `?filter=stw(name,"Millennium")`                                              |
|                            |                 | `enw`    | `?filter=enw(name,"Falcon")`                                                  |
|                            |                 | `reg`    | `?filter=reg(name,"^[a-zA-Z0-9 ]+$")`                                         |
| `setNumber`                | `integer`       | `eq`     | `?filter=eq(setNumber,1)`                                                     |
|                            |                 | `neq`    | `?filter=neq(setNumber,1)`                                                    |
|                            |                 | `gt`     | `?filter=gt(setNumber,1)`                                                     |
|                            |                 | `gte`    | `?filter=gte(setNumber,1)`                                                    |
|                            |                 | `lt`     | `?filter=lt(setNumber,1)`                                                     |
|                            |                 | `lte`    | `?filter=lte(setNumber,1)`                                                    |
| `pieces`                   | `integer`       | `eq`     | `?filter=eq(pieces,1)`                                                        |
|                            |                 | `neq`    | `?filter=neq(pieces,1)`                                                       |
|                            |                 | `gt`     | `?filter=gt(pieces,1)`                                                        |
|                            |                 | `gte`    | `?filter=gte(pieces,1)`                                                       |
|                            |                 | `lt`     | `?filter=lt(pieces,1)`                                                        |
|                            |                 | `lte`    | `?filter=lte(pieces,1)`                                                       |
| `price`                    | `double`        | `eq`     | `?filter=eq(price,1)`                                                         |
|                            |                 | `neq`    | `?filter=neq(price,1)`                                                        |
|                            |                 | `gt`     | `?filter=gt(price,1)`                                                         |
|                            |                 | `gte`    | `?filter=gte(price,1)`                                                        |
|                            |                 | `lt`     | `?filter=lt(price,1)`                                                         |
|                            |                 | `lte`    | `?filter=lte(price,1)`                                                        |
| `designerId`               | `uuid`          | `eq`     | `?filter=eq(designerId,"533d3fe3-bccc-405a-9904-4f516e892856")`               |
|                            |                 | `neq`    | `?filter=neq(designerId,"533d3fe3-bccc-405a-9904-4f516e892856")`              |
| `designer.id`              | `uuid`          | `eq`     | `?filter=eq(designer.id,"533d3fe3-bccc-405a-9904-4f516e892856")`              |
|                            |                 | `neq`    | `?filter=neq(designer.id,"533d3fe3-bccc-405a-9904-4f516e892856")`             |
| `designer.name`            | `string`        | `eq`     | `?filter=eq(designer.name,"Millennium Falcon")`                               |
|                            |                 | `neq`    | `?filter=neq(designer.name,"Millennium Falcon")`                              |
|                            |                 | `gt`     | `?filter=gt(designer.name,"Millennium Falcon")`                               |
|                            |                 | `gte`    | `?filter=gte(designer.name,"Millennium Falcon")`                              |
|                            |                 | `lt`     | `?filter=lt(designer.name,"Millennium Falcon")`                               |
|                            |                 | `lte`    | `?filter=lte(designer.name,"Millennium Falcon")`                              |
|                            |                 | `has`    | `?filter=has(designer.name,"Millennium")`                                     |
|                            |                 | `stw`    | `?filter=stw(designer.name,"Millennium")`                                     |
|                            |                 | `enw`    | `?filter=enw(designer.name,"Falcon")`                                         |
|                            |                 | `reg`    | `?filter=reg(designer.name,"^[a-zA-Z0-9 ]+$")`                                |
| `launchTime`               | `date-time`     | `eq`     | `?filter=eq(launchTime,"2025-03-16T14:15:30.500Z")`                           |
|                            |                 | `neq`    | `?filter=neq(launchTime,"2025-03-16T14:15:30.500Z")`                          |
|                            |                 | `gt`     | `?filter=gt(launchTime,"2025-03-16T14:15:30.500Z")`                           |
|                            |                 | `gte`    | `?filter=gte(launchTime,"2025-03-16T14:15:30.500Z")`                          |
|                            |                 | `lt`     | `?filter=lt(launchTime,"2025-03-16T14:15:30.500Z")`                           |
|                            |                 | `lte`    | `?filter=lte(launchTime,"2025-03-16T14:15:30.500Z")`                          |
| `packagingType`            | `PackagingType` | `eq`     | `?filter=eq(packagingType,"BOX")`                                             |
|                            |                 | `neq`    | `?filter=neq(packagingType,"BOX")`                                            |
| `theme`                    | `Theme`         | `eq`     | `?filter=eq(theme,"STAR_WARS")`                                               |
|                            |                 | `neq`    | `?filter=neq(theme,"STAR_WARS")`                                              |
| `categories.$it`           | `Category`      | `eq`     | `?filter=any(categories,eq($it,"ULTIMATE_COLLECTOR_SERIES"))`                 |
|                            |                 | `neq`    | `?filter=all(categories,neq($it,"ULTIMATE_COLLECTOR_SERIES"))`                |
| `minifigures.$it.id`       | `uuid`          | `eq`     | `?filter=any(minifigures,eq($it.id,"533d3fe3-bccc-405a-9904-4f516e892856"))`  |
|                            |                 | `neq`    | `?filter=all(minifigures,neq($it.id,"533d3fe3-bccc-405a-9904-4f516e892856"))` |
| `minifigures.$it.name`     | `string`        | `eq`     | `?filter=any(minifigures,eq($it.name,"Millennium Falcon"))`                   |
|                            |                 | `neq`    | `?filter=all(minifigures,neq($it.name,"Millennium Falcon"))`                  |
|                            |                 | `gt`     | `?filter=any(minifigures,gt($it.name,"Millennium Falcon"))`                   |
|                            |                 | `gte`    | `?filter=any(minifigures,gte($it.name,"Millennium Falcon"))`                  |
|                            |                 | `lt`     | `?filter=any(minifigures,lt($it.name,"Millennium Falcon"))`                   |
|                            |                 | `lte`    | `?filter=any(minifigures,lte($it.name,"Millennium Falcon"))`                  |
|                            |                 | `has`    | `?filter=any(minifigures,has($it.name,"Millennium"))`                         |
|                            |                 | `stw`    | `?filter=any(minifigures,stw($it.name,"Millennium"))`                         |
|                            |                 | `enw`    | `?filter=any(minifigures,enw($it.name,"Falcon"))`                             |
|                            |                 | `reg`    | `?filter=any(minifigures,reg($it.name,"^[a-zA-Z0-9 ]+$"))`                    |
| `minifigures.$it.quantity` | `integer`       | `eq`     | `?filter=any(minifigures,eq($it.quantity,1))`                                 |
|                            |                 | `neq`    | `?filter=all(minifigures,neq($it.quantity,1))`                                |
|                            |                 | `gt`     | `?filter=any(minifigures,gt($it.quantity,1))`                                 |
|                            |                 | `gte`    | `?filter=any(minifigures,gte($it.quantity,1))`                                |
|                            |                 | `lt`     | `?filter=any(minifigures,lt($it.quantity,1))`                                 |
|                            |                 | `lte`    | `?filter=any(minifigures,lte($it.quantity,1))`                                |

</details>