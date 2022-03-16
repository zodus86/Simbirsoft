
SELECT CONCAT (Books.Name, ', ',
	   Authors.FirstName, ' ',
	   Authors.LastName, ' ',
	   Authors.MiddleName)
FROM LibraryCard
JOIN Books ON Books.Id = LibraryCard.BookId
JOIN Authors ON Authors.Id = Books.AuthorId
WHERE LibraryCard.PersonId = 5