CREATE TABLE application.packaging_type
(
    id integer NOT NULL
        CONSTRAINT packaging_type_pkey
            PRIMARY KEY,
    name varchar(100) NOT NULL
);

ALTER TABLE application.packaging_type
    OWNER TO postgres;

CREATE UNIQUE INDEX packaging_type_name_key
    ON application.packaging_type (name);

