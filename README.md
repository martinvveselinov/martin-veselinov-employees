# martin-veselinov-employees
<h1>Sirma Solutions Software Developer Trainee - interview task</h1> </br></br>
This is a simple console app which determines the 2 employees which have worked together for the longest time.</br>
To use the app you have to place a data.txt or data.csv file in bin\Debug\net5.0\</br> 
The file must contain rows of data with the following pattern:</br>
143, 12, 2013-11-01, 2014-01-05</br>
218, 10, 2012-05-16, NULL</br>
143, 10, 2009-01-01, 2011-04-27</br>
...
</br>There are 4 columns - Employee ID, Project ID, Start date, End date (can be NULL - this means the employee is still working on this project)</br>
The purpose is to find those 2 employees, whom have worked on the same projects </br>(the same 2 employees can have worked on more than 1 project) for the longest time.
</br></br>
Sample output:</br>
Employee 185 and employee 132 have worked together on project 20 for 2952 days, which is the longest of all employees.    
