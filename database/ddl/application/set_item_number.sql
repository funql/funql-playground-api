CREATE TABLE application.set_item_number
(
    id uuid DEFAULT uuid_generate_v4() NOT NULL
        CONSTRAINT set_item_number_pkey
            PRIMARY KEY,
    set_id uuid NOT NULL
        CONSTRAINT set_item_number_set_id_fkey
            REFERENCES application.set (id)
            ON DELETE CASCADE,
    region_id integer NOT NULL
        CONSTRAINT set_item_number_region_id_fkey
            REFERENCES application.region (id)
            ON DELETE CASCADE,
    item_number integer NOT NULL
);

ALTER TABLE application.set_item_number
    OWNER TO postgres;

-- Unique region per set: only 1 entry per region allowed
CREATE UNIQUE INDEX set_item_number_set_id_region_id_key
    ON application.set_item_number (set_id, region_id);

