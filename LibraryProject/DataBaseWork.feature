Feature: DataBaseWork
	USER STORY!!!

@InsertData
Scenario Outline:  It is possible to insert data to Library DB
	When I create row in table "Authors" with data
		| AuthorName | PublishDate |
		| <author>   | <date>      |
	When I select whole "Authors" table
	Then Table contains data
		| AuthorName | PublishDate |
		| <author>   | <date>      |
	Examples:
		| author           | date       |
		| Taras Shevchenko | 1840-04-26 |
		| Nikolai Gogol    | 1809.01.04 |
