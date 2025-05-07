START TRANSACTION;

DO $$
BEGIN
-- Check if migration not yet applied
IF NOT EXISTS(SELECT 1 FROM migration.migration_history WHERE id = '20250507144000_add_sets') THEN

-- ============================ Migration start ============================

INSERT INTO application.theme (id, name)
VALUES  ('11', 'STRANGER_THINGS');

INSERT INTO application.designer (id, name)
VALUES  ('ee6f6c30-f413-414f-a58c-ae3abf7776a3', 'Hans Burkhard Schlömer'),
        ('3c82283c-94b5-4490-ba36-4656003ae5e7', 'César Soares'),
        ('939bc0a7-6ec0-4a4c-ba5c-78feafb34d15', 'Adam Grabowski'),
        ('bace78ea-9bcf-481a-97b7-907605f254a5', 'Joel Baker'),
        ('2540774f-20f3-42bd-81b2-96ca0fcb543a', 'Isaac Snyder'),
        ('5d70a1d6-b5c8-41e3-8cc9-0503adaec5fa', 'Justin Ramsden'),
        ('a4eb2eab-5e09-451b-9c34-8498a96c2765', 'Sven Franic'),
        ('2b0ff261-04c8-4d80-946b-4893f21a70e2', 'Ann Healy'),
        ('55c6ba29-fa48-4357-b221-cae954b3875b', 'Steen Sig Andersen');

INSERT INTO application.minifigure (id, name)
VALUES  ('24e029f5-fa56-45af-8969-239bd8202253', 'SW0661: BB-8 (Small Photoreceptor)'),
        ('9043d7ee-0748-4e6f-8017-3dcf7479ccd9', 'SW0700: C-3PO - Colorful Wires, Printed Legs'),
        ('1e6dfeb4-7438-4966-8d7a-dfa278426c69', 'SW0532: Chewbacca - Medium Nougat Fur'),
        ('c89725a9-2a39-462a-85dd-07de46757016', 'SW0676: Finn - Medium Nougat Jacket, Black Legs'),
        ('7d4b2343-493b-42d0-8664-dfd07dac15ab', 'SW0879: Han Solo, Dark Brown Legs with Holster Pattern, Dark Blue Jacket, Wavy Hair'),
        ('dfabd533-9aa5-4206-932f-96da879af457', 'SW0841: Han Solo, Old'),
        ('553e73ca-bcaf-46f4-b6c6-465c549b6b1b', 'SW0878: Princess Leia (Hoth Outfit White)'),
        ('2a8de620-687f-463b-9dea-fccfeebb2e35', 'SW0677: Rey - Dark Tan Tied Robe'),
        ('ee8513f8-f744-4450-98fc-f85baa757f73', 'SW1113: Din Grogu / The Child / ''Baby Yoda'''),
        ('8f111a86-2317-40ae-a09a-083f67e41826', 'SW1244: Kuiil - Backpack'),
        ('11f98b3a-84a3-4c77-8555-84a0bbb11abb', 'SW1242: The Mandalorian / Din Djarin / ''Mando'' - Brown Durasteel Armor, Printed Arms'),
        ('f6e2abd1-8338-4289-8fa5-24439c75458d', 'SW1243: The Mythrol'),
        ('63c949d4-3516-44a4-95b7-503e02a6e2a6', 'SH0791: Batman - Black Suit with Copper Belt and Printed Legs (Type 2 Cowl)'),
        ('04529baa-aa1e-4871-8011-bad40c3404b7', 'SH0792: The Joker - Green Vest and Printed Arms'),
        ('0dfe4a01-51f7-42a8-9941-212d20369a5b', '90398PB020: Albus Dumbledore Statuette / Trophy'),
        ('f9be0eed-1124-4d24-847b-474d33f8ffcb', '90398PB025: Argus Filch Statuette / Trophy'),
        ('0a3c7f4c-c3a9-4517-97ea-90f97d5c751b', '90398PB026: Bellatrix Lestrange Statuette / Trophy'),
        ('88f1e296-17fc-4eb6-bf0a-cecb3d792a1d', '90398PB015: Draco Malfoy Statuette / Trophy - Slytherin Robe'),
        ('f83d17bb-e23d-46e6-be84-df243a0838ce', 'HP159: Godric Gryffindor'),
        ('a0d73199-1efd-491e-92f5-58637711b022', '90398PB027: Gryffindor Student Statuette / Trophy #1, Dark Brown Hair'),
        ('414571f3-bf2e-4e76-a94e-f8cb14316923', '90398PB028: Gryffindor Student Statuette / Trophy #2, Dark Red Hair'),
        ('e3c32440-2582-4abd-bfd6-ecbd6ae8654f', '90398PB029: Gryffindor Student Statuette / Trophy #3, Black Hair'),
        ('37bccc6d-89e7-4cd9-901c-d59b76e4c3b5', '90398PB016: Harry Potter Statuette / Trophy - Gryffindor Robe'),
        ('05ea5e74-ae04-483c-a52e-0a90e60f6f5a', 'HP160: Helga Hufflepuff'),
        ('03b2aa38-ae8b-492f-b44f-d3a26a494be1', '90398PB017: Hermione Granger Statuette / Trophy - Gryffindor Robe'),
        ('17083d1d-44ff-4b81-a9c6-826803e476b1', '90398PB030: Hufflepuff Student Statuette / Trophy #1, Nougat Face'),
        ('788a1727-ad38-4e03-b973-31ac95427d76', '90398PB031: Hufflepuff Student Statuette / Trophy #2, Reddish Brown Face'),
        ('790aa318-6ec0-489e-b0b0-a10d27b3f855', '90398PB032: Hufflepuff Student Statuette / Trophy #3, Light Nougat Face'),
        ('d9b50d28-aaa7-44c3-9f75-9c6efdc8f5fd', '90398PB018: Lord Voldemort Statuette / Trophy'),
        ('802eefbf-837d-460e-899f-d843062665e5', '90398PB021: Professor Dolores Umbridge Statuette / Trophy'),
        ('34dfb592-8005-4990-89ef-cf859872e3a3', '90398PB022: Professor Minerva McGonagall Statuette / Trophy'),
        ('2787162a-2d03-4830-8d81-d2c1bf4c09b8', '90398PB024: Professor Remus Lupin Statuette / Trophy'),
        ('daddb084-c48b-4c8b-9a6d-1790ff40fe32', '90398PB023: Professor Severus Snape Statuette / Trophy'),
        ('8044734f-3310-4cc1-96d1-ad936e8aaa6b', '90398PB033: Ravenclaw Student Statuette / Trophy #1, Black Hair, Light Nougat Face'),
        ('ea5466af-6d34-4177-9d7f-3b0d08ea9ced', '90398PB034: Ravenclaw Student Statuette / Trophy #2, Bright Light Yellow Hair, Light Nougat Face'),
        ('2f73399f-5ba3-493c-8ab5-80db30254d08', '90398PB035: Ravenclaw Student Statuette / Trophy #3, Black Hair, Reddish Brown Face'),
        ('301e7809-6407-4204-a039-024c3bb7cd3e', '90398PB019: Ron Weasley Statuette / Trophy - Gryffindor Robe'),
        ('303c08d0-edcd-4f7f-b379-589a44aad8e9', 'HP162: Rowena Ravenclaw'),
        ('b37f9cc0-b58f-4542-8d0a-bcf4e9f218b1', 'HP161: Salazar Slytherin'),
        ('db320b68-1fd9-42fe-8a9f-eb598ac7c7f4', '90398PB036: Slytherin Student Statuette / Trophy #1, Nougat Face'),
        ('87184c62-7706-4709-a8a8-6f7056c795bd', '90398PB037: Slytherin Student Statuette / Trophy #2, Reddish Brown Face'),
        ('875206ce-2b72-40fb-b7aa-4ee2ee8d8d33', '90398PB038: Slytherin Student Statuette / Trophy #3, Light Nougat Face'),
        ('1cf3d2a4-0295-4d5e-be46-532f19a126ce', 'HFW001: Aloy - Lopsided Closed Mouth / Surprised Open Mouth'),
        ('1c50403c-3241-4d1c-9d18-003938805493', 'HFW002: Watcher'),
        ('3c7e46a7-469f-4d8e-aa3b-3c82da432a5d', 'ST007: Chief Jim Hopper'),
        ('633a3e92-3910-425e-953d-3088b1c823fc', 'ST008: Demogorgon'),
        ('79b853a6-1d09-490a-ac51-b76f32a13aac', 'ST005: Dustin Henderson'),
        ('0bb5bc76-2ba7-472a-b291-1c25fcf2e43a', 'ST001: Eleven'),
        ('f424b111-7ae6-4ccc-b3ac-9b9bc872923b', 'ST002: Joyce Byers'),
        ('bf6f4282-5f53-4698-913d-5e02ce2a956d', 'ST006: Lucas Sinclair'),
        ('4bb4d2e3-aec1-4f74-886a-bcba645c3fe0', 'ST004: Mike Wheeler'),
        ('6ca3e651-520d-4ecc-9a0f-dae35d4def81', 'ST003: Will Byers'),
        ('3a31e2ef-07be-461a-9ea1-b738ba1372d0', 'BTF002: Doc Brown - Long Hair, Yellow Coat'),
        ('3a8ea3b8-a22c-448d-af62-eefd7d461e6a', 'BTF001: Marty McFly - Red Jacket with Pockets, Dark Bluish Gray Arms'),
        ('981726a7-a778-4ffe-bf88-fc7daa16a32f', 'TWN497: Ayrton Senna');

INSERT INTO application.set (id, name, set_number, pieces, price, designer_id, launch_time, packaging_type_id, theme_id)
VALUES  ('041a9eed-1665-40e5-876e-1875460cf730', 'LEGO Star Wars Millennium Falcon', '75192', '7541', '849.99', 'ee6f6c30-f413-414f-a58c-ae3abf7776a3', '2017-10-01 00:00:00.000000 +00:00', '1', '9'),
        ('4ebe2131-528f-4d73-b4b4-348a9d383bd3', 'LEGO Star Wars The Razor Crest', '75331', '6187', '599.99', '3c82283c-94b5-4490-ba36-4656003ae5e7', '2022-10-03 00:00:00.000000 +00:00', '1', '9'),
        ('255fe9a9-acb5-445b-98f1-092cfe4c2272', 'LEGO DC Batman Batmobile Tumbler', '76240', '2049', '269.99', '939bc0a7-6ec0-4a4c-ba5c-78feafb34d15', '2021-11-01 00:00:00.000000 +00:00', '1', '1'),
        ('7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', 'LEGO Harry Potter Hogwarts Castle', '71043', '6020', '469.99', 'bace78ea-9bcf-481a-97b7-907605f254a5', '2018-09-01 00:00:00.000000 +00:00', '1', '4'),
        ('36fa1db6-f5e6-4b97-8f88-ab99a3aab971', 'LEGO Horizon Forbidden West Tallneck', '76989', '1222', '89.99', '2540774f-20f3-42bd-81b2-96ca0fcb543a', '2022-05-01 00:00:00.000000 +00:00', '1', '5'),
        ('dbb6d273-c3b8-463d-8195-c63d6b641e47', 'LEGO Stranger Things The Upside Down', '75810', '2287', '199.99', '5d70a1d6-b5c8-41e3-8cc9-0503adaec5fa', '2019-06-01 00:00:00.000000 +00:00', '1', '11'),
        ('7e06b6ef-cc2c-43c8-bd86-7f57e6f067b0', 'LEGO Icons Back to the Future Time Machine', '10300', '1872', '199.99', 'a4eb2eab-5e09-451b-9c34-8498a96c2765', '2022-04-01 00:00:00.000000 +00:00', '1', '5'),
        ('78ff8cd0-cba4-45f2-82e8-4d97dd2561a6', 'LEGO Icons McLaren MP4/4 & Ayrton Senna', '10330', '693', '79.99', '2b0ff261-04c8-4d80-946b-4893f21a70e2', '2024-03-01 00:00:00.000000 +00:00', '1', '5'),
        ('7dd82bbe-6f92-4e2c-a293-305644c66a4e', 'LEGO Ideas WALL-E', '21303', '677', '49.99', '55c6ba29-fa48-4357-b221-cae954b3875b', '2015-09-01 00:00:00.000000 +00:00', '1', '6');

INSERT INTO application.set_category (id, set_id, category_id)
VALUES  ('990b3919-be6d-49a1-a3cb-91782213f6f8', '041a9eed-1665-40e5-876e-1875460cf730', '1'),
        ('2847b3fa-542c-40f2-a742-7fd52d56159c', '041a9eed-1665-40e5-876e-1875460cf730', '2'),
        ('3f2dd425-82d5-4fbd-a881-63cf1bedf1cb', '041a9eed-1665-40e5-876e-1875460cf730', '3'),
        ('03c74bf4-c10c-4034-839a-0032e4d0d14e', '4ebe2131-528f-4d73-b4b4-348a9d383bd3', '1'),
        ('cef03e80-9842-4a10-9c26-4b6c891ea22a', '4ebe2131-528f-4d73-b4b4-348a9d383bd3', '2'),
        ('cd7931f2-09a4-4de2-a628-3260e5b4b9a3', '4ebe2131-528f-4d73-b4b4-348a9d383bd3', '3'),
        ('912dd1ec-0b9f-4757-bd7e-53de13a8ea19', '255fe9a9-acb5-445b-98f1-092cfe4c2272', '1'),
        ('084e92f6-3d05-48ed-adc3-2bd8b05d6863', '255fe9a9-acb5-445b-98f1-092cfe4c2272', '2'),
        ('e1bfb0f9-eb96-4d99-a101-31f2f97fc95c', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '1'),
        ('a9f6a9aa-14d7-4905-bc25-7fb7a6b51ae2', 'dbb6d273-c3b8-463d-8195-c63d6b641e47', '1'),
        ('7660f819-2e3e-4e8f-a946-2feb70f8cf2b', '7e06b6ef-cc2c-43c8-bd86-7f57e6f067b0', '1'),
        ('27930cac-d90b-4fd7-b95a-775e8f495089', '7e06b6ef-cc2c-43c8-bd86-7f57e6f067b0', '2'),
        ('6c82a721-3106-4abd-bc82-1a156f2f9a6a', '78ff8cd0-cba4-45f2-82e8-4d97dd2561a6', '2'),
        ('2b19d781-6723-4b7d-b08a-4569312c7e48', '7dd82bbe-6f92-4e2c-a293-305644c66a4e', '1');

INSERT INTO application.set_item_number (id, set_id, region_id, item_number)
VALUES  ('183d3209-0116-4945-917e-7e28d538920f', '041a9eed-1665-40e5-876e-1875460cf730', '1', '6175770'),
        ('bfb431bd-aa71-45b0-861d-4139c907cc17', '041a9eed-1665-40e5-876e-1875460cf730', '2', '6175771'),
        ('30e55acb-93fa-4586-8029-736d56caec24', '4ebe2131-528f-4d73-b4b4-348a9d383bd3', '1', '6378869'),
        ('230fdc8e-2cd8-414d-9489-e6effea58a05', '4ebe2131-528f-4d73-b4b4-348a9d383bd3', '2', '6378936'),
        ('f2d18e7c-f511-4269-8ebf-77d23a7afe00', '255fe9a9-acb5-445b-98f1-092cfe4c2272', '1', '6365777'),
        ('b4e24a75-8203-42d0-a28b-d4df6eed6bcf', '255fe9a9-acb5-445b-98f1-092cfe4c2272', '2', '6365778'),
        ('f087e6d2-9b08-4d71-8611-718607e52abc', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '1', '6212630'),
        ('2d47bd1a-d769-4d70-8ad1-293db4a8110f', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '2', '6212631'),
        ('ff974863-9757-4d94-a6a6-0d86c34744b6', '36fa1db6-f5e6-4b97-8f88-ab99a3aab971', '1', '6379696'),
        ('acac446b-873b-442d-9857-ca56118e55e5', '36fa1db6-f5e6-4b97-8f88-ab99a3aab971', '2', '6379697'),
        ('9e9c4599-9942-47b1-87ef-2e8ca94cd27c', 'dbb6d273-c3b8-463d-8195-c63d6b641e47', '1', '6265596'),
        ('b8e354ae-1c68-400c-89fe-c14f9e8ef41f', 'dbb6d273-c3b8-463d-8195-c63d6b641e47', '2', '6265597'),
        ('e3a1c9ad-59fb-4c83-9d1e-7d0b86447c9d', '7e06b6ef-cc2c-43c8-bd86-7f57e6f067b0', '1', '6379764'),
        ('1c219d84-ea7c-423f-a35d-dcdd008c6a0c', '7e06b6ef-cc2c-43c8-bd86-7f57e6f067b0', '2', '6379765'),
        ('8a0d173b-3ccc-42dc-88b4-eee10b27bbea', '78ff8cd0-cba4-45f2-82e8-4d97dd2561a6', '1', '6470463'),
        ('f5e9dc33-4e66-4f60-9395-f77654215a1d', '78ff8cd0-cba4-45f2-82e8-4d97dd2561a6', '2', '6470464'),
        ('74d34e44-ff98-4cf9-bcb3-acb3d9d86b6a', '7dd82bbe-6f92-4e2c-a293-305644c66a4e', '1', '6128858'),
        ('9bf47382-1ae5-4f71-9d1a-2bbba4eb73fe', '7dd82bbe-6f92-4e2c-a293-305644c66a4e', '2', '6128859');

INSERT INTO application.set_minifigure (id, set_id, minifigure_id, quantity)
VALUES  ('c2ea4563-6ddf-4739-962d-6eef724643ef', '041a9eed-1665-40e5-876e-1875460cf730', '24e029f5-fa56-45af-8969-239bd8202253', '1'),
        ('90774c5e-a0b8-489b-bc85-c2e8615277fa', '041a9eed-1665-40e5-876e-1875460cf730', '9043d7ee-0748-4e6f-8017-3dcf7479ccd9', '1'),
        ('530fbb58-e0b3-4493-9783-b3968462a235', '041a9eed-1665-40e5-876e-1875460cf730', '1e6dfeb4-7438-4966-8d7a-dfa278426c69', '1'),
        ('2de529f7-aa80-4e68-a4c6-9c7151d82561', '041a9eed-1665-40e5-876e-1875460cf730', 'c89725a9-2a39-462a-85dd-07de46757016', '1'),
        ('32f67479-99fe-4290-b86e-41ee57e14590', '041a9eed-1665-40e5-876e-1875460cf730', '7d4b2343-493b-42d0-8664-dfd07dac15ab', '1'),
        ('6e96eb36-df5d-4d4e-9907-cfc7c564b779', '041a9eed-1665-40e5-876e-1875460cf730', 'dfabd533-9aa5-4206-932f-96da879af457', '1'),
        ('146c0e19-7b76-4d23-8676-a5c38a0565d2', '041a9eed-1665-40e5-876e-1875460cf730', '553e73ca-bcaf-46f4-b6c6-465c549b6b1b', '1'),
        ('623f8a0d-1c2a-41c1-abf9-a59975b574dd', '041a9eed-1665-40e5-876e-1875460cf730', '2a8de620-687f-463b-9dea-fccfeebb2e35', '1'),
        ('ef72cc89-b93c-4037-936c-3bdc325eaf78', '4ebe2131-528f-4d73-b4b4-348a9d383bd3', 'ee8513f8-f744-4450-98fc-f85baa757f73', '1'),
        ('26d254db-546a-4280-9730-78182283c70b', '4ebe2131-528f-4d73-b4b4-348a9d383bd3', '8f111a86-2317-40ae-a09a-083f67e41826', '1'),
        ('b9ec3440-966b-48fe-9036-0db1f7b27f73', '4ebe2131-528f-4d73-b4b4-348a9d383bd3', '11f98b3a-84a3-4c77-8555-84a0bbb11abb', '1'),
        ('5c992fc9-5f11-42f5-8197-3fea413ca68b', '4ebe2131-528f-4d73-b4b4-348a9d383bd3', 'f6e2abd1-8338-4289-8fa5-24439c75458d', '1'),
        ('78bd1e4f-ecc5-4f4d-b15d-b460e3f933c3', '255fe9a9-acb5-445b-98f1-092cfe4c2272', '63c949d4-3516-44a4-95b7-503e02a6e2a6', '1'),
        ('2ec24454-84b0-4b05-b848-f1ef2c9a7cc7', '255fe9a9-acb5-445b-98f1-092cfe4c2272', '04529baa-aa1e-4871-8011-bad40c3404b7', '1'),
        ('acccea1d-e65b-47bc-897a-e418c0339bb6', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '0dfe4a01-51f7-42a8-9941-212d20369a5b', '1'),
        ('d9dc9b42-70c0-44fb-af62-d10c8361a192', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', 'f9be0eed-1124-4d24-847b-474d33f8ffcb', '1'),
        ('080c9733-53a3-4ee5-8d03-5ff9fd3ca689', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '0a3c7f4c-c3a9-4517-97ea-90f97d5c751b', '1'),
        ('f0a54cf1-e3a9-4ae1-945b-6627916cee81', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '88f1e296-17fc-4eb6-bf0a-cecb3d792a1d', '1'),
        ('32c63b6b-cb93-4392-9416-eedf2f7a7345', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', 'f83d17bb-e23d-46e6-be84-df243a0838ce', '1'),
        ('ad9d2932-49f4-4d1a-9cf8-52ca0015e45e', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', 'a0d73199-1efd-491e-92f5-58637711b022', '1'),
        ('22d5b29d-acc6-4cef-9d65-202c7a188b21', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '414571f3-bf2e-4e76-a94e-f8cb14316923', '1'),
        ('c24d582a-193c-4ec8-9fe6-01a9bf256d70', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', 'e3c32440-2582-4abd-bfd6-ecbd6ae8654f', '1'),
        ('147f19a2-59ca-4d67-a5dd-0558657a2bc6', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '37bccc6d-89e7-4cd9-901c-d59b76e4c3b5', '1'),
        ('eca0242d-9269-45ae-b3f0-374afa22da44', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '05ea5e74-ae04-483c-a52e-0a90e60f6f5a', '1'),
        ('a52bef71-40f3-4231-87d9-941e01652285', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '03b2aa38-ae8b-492f-b44f-d3a26a494be1', '1'),
        ('1b647636-375d-4ee3-b648-bb76229329af', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '17083d1d-44ff-4b81-a9c6-826803e476b1', '1'),
        ('678bd4d0-9e11-43cd-8205-aad04fe08807', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '788a1727-ad38-4e03-b973-31ac95427d76', '1'),
        ('98846c25-ccf6-4a7f-842d-f2fade51f1e5', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '790aa318-6ec0-489e-b0b0-a10d27b3f855', '1'),
        ('74af058f-9f78-4b53-8255-baae422206c3', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', 'd9b50d28-aaa7-44c3-9f75-9c6efdc8f5fd', '1'),
        ('bd24f9ed-13ee-41c3-a537-50834d3f2341', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '802eefbf-837d-460e-899f-d843062665e5', '1'),
        ('f28d2592-9917-40de-a987-66b7827eae41', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '34dfb592-8005-4990-89ef-cf859872e3a3', '1'),
        ('79c28e53-de1c-4bad-a280-2c13cb85f443', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '2787162a-2d03-4830-8d81-d2c1bf4c09b8', '1'),
        ('8bf2c003-72e9-46d2-815f-72384ae87242', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', 'daddb084-c48b-4c8b-9a6d-1790ff40fe32', '1'),
        ('39150630-4bc8-44c9-a3ae-d0aa9b180acb', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '8044734f-3310-4cc1-96d1-ad936e8aaa6b', '1'),
        ('771e5335-ea15-4cd2-b535-d6e5661453a7', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', 'ea5466af-6d34-4177-9d7f-3b0d08ea9ced', '1'),
        ('dff09cd8-0306-4ef1-ac44-a82e79e54aae', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '2f73399f-5ba3-493c-8ab5-80db30254d08', '1'),
        ('acf6cb92-6584-4660-a67d-6d0fa68d3f61', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '301e7809-6407-4204-a039-024c3bb7cd3e', '1'),
        ('a7a8665c-2c74-45d3-bef8-9990b387e370', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '303c08d0-edcd-4f7f-b379-589a44aad8e9', '1'),
        ('e8011520-ae43-48c3-9cc3-b6fba5cb6808', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', 'b37f9cc0-b58f-4542-8d0a-bcf4e9f218b1', '1'),
        ('50c0b328-da1f-4277-ba6d-42dd4d2ece4d', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', 'db320b68-1fd9-42fe-8a9f-eb598ac7c7f4', '1'),
        ('0c9c045a-e9de-4f26-99e9-96c477199152', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '87184c62-7706-4709-a8a8-6f7056c795bd', '1'),
        ('33803013-c2ed-455f-9a48-c76ddbbfe489', '7e2f89ad-c69f-4bf5-a86c-60b48d793a7b', '875206ce-2b72-40fb-b7aa-4ee2ee8d8d33', '1'),
        ('4676b971-f899-4908-91be-4f11b6261315', '36fa1db6-f5e6-4b97-8f88-ab99a3aab971', '1cf3d2a4-0295-4d5e-be46-532f19a126ce', '1'),
        ('aab7a608-ceba-4cae-9660-a6e8293c4cb6', '36fa1db6-f5e6-4b97-8f88-ab99a3aab971', '1c50403c-3241-4d1c-9d18-003938805493', '1'),
        ('bd61a07b-2a7b-40f6-bcd7-3e0e5b5e4026', 'dbb6d273-c3b8-463d-8195-c63d6b641e47', '3c7e46a7-469f-4d8e-aa3b-3c82da432a5d', '1'),
        ('e26b8230-5e64-440d-9893-f91b1f68b70d', 'dbb6d273-c3b8-463d-8195-c63d6b641e47', '633a3e92-3910-425e-953d-3088b1c823fc', '1'),
        ('90d26faa-d068-4ab0-a747-7320da7c2d5f', 'dbb6d273-c3b8-463d-8195-c63d6b641e47', '79b853a6-1d09-490a-ac51-b76f32a13aac', '1'),
        ('1768fc67-59e8-4790-886c-560c992d5968', 'dbb6d273-c3b8-463d-8195-c63d6b641e47', '0bb5bc76-2ba7-472a-b291-1c25fcf2e43a', '1'),
        ('3bfc4383-9f66-4d32-a135-6de3fa294ed6', 'dbb6d273-c3b8-463d-8195-c63d6b641e47', 'f424b111-7ae6-4ccc-b3ac-9b9bc872923b', '1'),
        ('4e5de8df-9814-4335-902d-0871ed4eb542', 'dbb6d273-c3b8-463d-8195-c63d6b641e47', 'bf6f4282-5f53-4698-913d-5e02ce2a956d', '1'),
        ('065f2912-2b4d-427b-89ff-60317518f931', 'dbb6d273-c3b8-463d-8195-c63d6b641e47', '4bb4d2e3-aec1-4f74-886a-bcba645c3fe0', '1'),
        ('cdbd9edf-87b1-419a-ab93-9fdd4e8bcb06', 'dbb6d273-c3b8-463d-8195-c63d6b641e47', '6ca3e651-520d-4ecc-9a0f-dae35d4def81', '1'),
        ('c3109562-b892-4413-99b8-09b6994994f4', '7e06b6ef-cc2c-43c8-bd86-7f57e6f067b0', '3a31e2ef-07be-461a-9ea1-b738ba1372d0', '1'),
        ('fd001713-9f07-482b-883e-07bed41fed10', '7e06b6ef-cc2c-43c8-bd86-7f57e6f067b0', '3a8ea3b8-a22c-448d-af62-eefd7d461e6a', '1'),
        ('c5dcbe2e-3e4a-4126-b972-caf6e8cb36d9', '78ff8cd0-cba4-45f2-82e8-4d97dd2561a6', '981726a7-a778-4ffe-bf88-fc7daa16a32f', '1');

-- ============================ Migration end ============================

-- Migration applied, so update history
INSERT INTO migration.migration_history (id)
VALUES ('20250507144000_add_sets');

END IF;
END $$;

COMMIT;

