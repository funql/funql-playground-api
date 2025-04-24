CREATE TABLE application.designer
(
    id uuid DEFAULT uuid_generate_v4() NOT NULL
        CONSTRAINT designer_pkey
            PRIMARY KEY,
    name varchar(255) NOT NULL
);

ALTER TABLE application.designer
    OWNER TO postgres;