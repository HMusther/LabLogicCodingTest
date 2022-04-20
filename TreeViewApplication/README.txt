Approach:
My approach was to have a list of "TreeElement" objects, which could either
be Folder or Item which inherit from TreeElement in order to be able to
store them all in the same list.

Folder inherits from TreeElement and includes a list of TreeElements to
store contents within that Folder

Item inherits from TreeElement and only has a name

To find items within folders, I used recursion to follow each folder within the root
to search for items nested within the folders.

Issues:
Using this approach, I struggled to be able to move folders within the tree
and would have to take a different approach to store items, same with deleting files.


USAGE
"root" - Show all files from root folders
"goto [index]" where index is a folder's index
"search [query]" where query is the name of a folder or item"
