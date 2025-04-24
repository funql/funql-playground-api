CREATE TABLE application.set_minifigure
(
    id uuid DEFAULT uuid_generate_v4() NOT NULL
        CONSTRAINT set_minifigure_pkey
            PRIMARY KEY,
    set_id uuid NOT NULL
        CONSTRAINT set_minifigure_set_id_fkey
            REFERENCES application.set (id)
            ON DELETE CASCADE,
    minifigure_id uuid NOT NULL
        CONSTRAINT set_minifigure_minifigure_id_fkey
            REFERENCES application.minifigure (id)
            ON DELETE CASCADE,
    quantity integer NOT NULL   
);

ALTER TABLE application.set_minifigure
    OWNER TO postgres;

-- Unique minifigure per set: only 1 entry per minifigure allowed
CREATE UNIQUE INDEX set_minifigure_set_id_minifigure_id_key
    ON application.set_minifigure (set_id, minifigure_id);

