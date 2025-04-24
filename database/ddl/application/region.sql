CREATE TABLE application.region
(
    id integer NOT NULL
        CONSTRAINT region_pkey
            PRIMARY KEY,
    name varchar(100) NOT NULL
);

ALTER TABLE application.region
    OWNER TO postgres;

CREATE UNIQUE INDEX region_name_key
    ON application.region (name);

