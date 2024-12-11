# ClassListFinder
A potentially handy tool for getting your major's class list names and descriptions</br>
Just provide a vaid [mnsu.edu/academics/academic-catalog/all-active-catalogs/](mnsu.edu/academics/academic-catalog/all-active-catalogs) link ending in `#CourseList` and you _should_ be good to go!

You will also be prompted if you want the result copied to your clipboard.
As a fair warning the text output can be pretty large, so don't say I didn't warn you.

That's it! I made this tool for myself and spent 3 hours trying to save 15 minutes.

Cheers!

> [!NOTE]
> The `GetList` method in [ClassListGrabber](ClassListGrabber.cs) outputs a string in the format:</br>
> ```{CourseName}\n{CourseDescription}\n\n``` All console control is done in [Program](Program.cs)*</br>
> _~If you care to do anything with it_
