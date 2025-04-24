CREATE TABLE application.set_category
(
    id uuid DEFAULT uuid_generate_v4() NOT NULL
        CONSTRAINT set_category_pkey
            PRIMARY KEY,
    set_id uuid NOT NULL
        CONSTRAINT set_category_set_id_fkey
            REFERENCES application.set (id)
            ON DELETE CASCADE,
    category_id integer NOT NULL
        CONSTRAINT set_category_category_id_fkey
            REFERENCES application.category (id)
            ON DELETE CASCADE
);

ALTER TABLE application.set_category
    OWNER TO postgres;

-- Unique category per set: only 1 entry per category allowed
CREATE UNIQUE INDEX set_category_set_id_category_id_key
    ON application.set_category (set_id, category_id);

