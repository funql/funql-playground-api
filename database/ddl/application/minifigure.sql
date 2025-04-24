CREATE TABLE application.minifigure
(
    id uuid DEFAULT uuid_generate_v4() NOT NULL
        CONSTRAINT minifigure_pkey
            PRIMARY KEY,
    name varchar(255) NOT NULL
);

ALTER TABLE application.minifigure
    OWNER TO postgres;