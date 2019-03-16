# Blog Engine Expanded
1.	_Layout.cshtml
*	Your layout file will have a link to both a ‘Register’ view and a ‘Login’ view.
*	If the user is logged in display their First and Last name on the page somewhere.
*	If the user is logged in display a link to the ‘EditProfile’ view.
*	If the user is an administrator display a link to the ‘AddBlogPost’ view.
*	If the user is an administrator display a link to the ‘ViewBadWords’ view.
*	Your layout file should contain your First Name, Last Name, Email Address and Student Number in the footer.
* I encourage you to create a theme using either custom CSS, or a framework like bootstrap.
2.	Home Controller / Register
*	This view will allow users to create ‘User’ accounts to be stored in your database. 
* Create a form that creates a User model and collects the following fields: 
*	FirstName, LastName, EmailAddress, Password, Role, DateOfBirth, City, Address, PostalCode and Country
*	Once you have collected the data from the client, store it in the database and redirect the user to the Login view
*	Note, I know this is not standard practice, but allow this screen to create both ‘Admin’ users and ‘General Users’. This is simply so we can test the application easily.
3.	Home Controller / EditProfile
*	This view will a user to modify the details collected in the ‘Register’ view.
* This view can only be accessed after the user logs into the application.
4.	Home Controller / Login
*	This view will allow the users to log in to your application.
* Create a form that accepts the users email address and password.
*	Once the form is submitted authenticate the user. If the user is valid redirect them to the ‘Index’ view
*	Note store the ‘UserId’ of the user in the Session so you can retrieve it for other subsequent views.
5.	Home Controller / Index
*	This view will list all the BlogPosts 
* You will display ‘Title’, the ShortDescription and the ‘Posted’ fields from each BlogPost object in your database
*	The Title of each blog post will be a link to the ‘DisplayFullBlogPost’ view
*	If the user is logged in as an administrator each blog post will display a link to the ‘EditBlogPost’ view as well as the other requirements above.
*	If the user is logged in as an administrator each blog post will display a link to delete the blog post from the database.
6.	Home Controller / DisplayFullBlogPost
*	This view will list the Title, Content, Posted value, the email address and full name of the users who created the post and all the images associated with the blog post.
* If the user is logged in they should be able to comment on the blog post using a comments text box at the bottom of the screen. 
*	When a user posts a comment, the comment should be scanned for Bad Words listed in the BadWords table of your database If a word is found replace that word content with *****
*	Display all comments associated with the blog post.
7.	Home Controller / AddBlogPost
*	This view will collect the data needed to create a blog post. 
* Use a form to collect Title, ShortDescription, Content, Posted (date time), IsAvailable 
*	This view can only be accessed after the user logs into the application.
8.	Home Controller / EditBlogPost
*	This view will allow an administrator to modify the data of a selected blog post.
* Use a form to collect the modified Title, ShortDescription, Content, Posted (date time), IsAvailable content.
*	This view will also allow a user to add or delete images for a blog post. 
*	This view can only be accessed after the user logs into the application.
9. Home Controller / ViewBadWords
*	This view will allow an administrator to define a set of restricted words that will be ‘starred-out’ when a user posts a comment.
* This page will contain:  
   A form at the top of the page to submit new ‘Bad Words’.  
   A list of the bad words that are currently in the databas* The administrator should be able to delete bad words.  
   This view can only be accessed after the user logs into the application.  
