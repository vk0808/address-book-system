USE address_book;

ALTER TABLE address
ADD AddedDate DATE NULL;

UPDATE address SET AddedDate='2020-10-03' WHERE FirstName='Porvi';
UPDATE address SET AddedDate='2019-09-10' WHERE FirstName='Anand' AND BookID=12;
UPDATE address SET AddedDate='2020-07-03' WHERE FirstName='Ravi';
UPDATE address SET AddedDate='2018-10-03' WHERE FirstName='Rahul';

SELECT * FROM address;