SELECT rw.name, b.title, rt.rating, rt.rating_date from ratings rt
INNER JOIN books b
	ON rt.book_id = b.id
INNER JOIN reviewers rw
	ON rw.id = rt.reviewer_id
ORDER BY rw.name ASC,  b.title ASC, rt.rating DESC