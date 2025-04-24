CREATE TABLE application.theme
(
    id integer NOT NULL
        CONSTRAINT theme_pkey
            PRIMARY KEY,
    name varchar(100) NOT NULL
);

ALTER TABLE application.theme
    OWNER TO postgres;

CREATE UNIQUE INDEX theme_name_key
    ON application.theme (name);

