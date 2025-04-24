CREATE TABLE application.set
(
    id uuid DEFAULT uuid_generate_v4() NOT NULL
        CONSTRAINT set_pkey
            PRIMARY KEY,
    name varchar(255) NOT NULL,
    set_number integer NOT NULL,
    pieces integer NOT NULL,
    price numeric(19, 4) NOT NULL,
    designer_id uuid NOT NULL
        CONSTRAINT set_designer_id_fkey
            REFERENCES application.designer (id),
    launch_time timestamp WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP NOT NULL,
    packaging_type_id integer NOT NULL 
        CONSTRAINT set_packaging_type_id_fkey
            REFERENCES application.packaging_type (id),
    theme_id integer NOT NULL
        CONSTRAINT set_theme_id_fkey
            REFERENCES application.theme (id)
);

ALTER TABLE application.set
    OWNER TO postgres;

CREATE UNIQUE INDEX set_set_number_key
    ON application.set (set_number);