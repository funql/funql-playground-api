CREATE TABLE application.category
(
    id integer NOT NULL
        CONSTRAINT category_pkey
            PRIMARY KEY,
    name varchar(100) NOT NULL
);

ALTER TABLE application.category
    OWNER TO postgres;

CREATE UNIQUE INDEX category_name_key
    ON application.category (name);

