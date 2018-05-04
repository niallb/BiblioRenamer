# BiblioRenamer
Simple tool for copying and renaming files by dragging them onto a list of names generated from a RefWorks file.

This is a very basic app, created to fit my own requirements. Feel free to modify it - it is a Visual Studio 2013 project. 
If you add an improvement that others might find useful please consider me a pull request so I can update this version. 

The purpose of this tool is to help with sorting out lots of (poorly named) downloads of academic papers to make them easier to 
find, and suitable for adding to an e-reader. I've decided on a format that uses up to two author surnames followed by the year 
and the title, all truncated to 120 characters as the filename format, and this is currently hard coded into the program.

To use the program, create a bibliography in RefWorks format (I export from Zotero), and use File->Open to load it.

From the options menu, select an output directory. (The default is to use the dir the file is in, if an output directory is not set.)

Once this is done, you can drag files onto the list of names, and they will be copied with the name they are dragged onto.

There are two other items in the options menu, to delete the original file, and to remove the new file name from the list once 
it has been used. 

This is a very quick piece of coding - less than two hours work in total - so don't expect much polish, however I hopw it 
will be useful for others. 
