
SELECT CONCAT(
	   Authors.FirstName, ' ',
	   Authors.LastName, ' ',
	   Authors.MiddleName, ' ',
	   Books.Name)
FROM LibraryCard
JOIN Books ON Books.Id = LibraryCard.BookId
JOIN Authors ON Authors.Id = Books.AuthorId
