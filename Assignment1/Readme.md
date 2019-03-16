# Blog Engine
ASP.NET COre Web Application contain Home, Views, Model.

### Model:
1.Role

2.User

3.Blog Post

4.Comment

#### Application Logic:
1.	_Layout.cshtml
* Layout file will have a link to both a ‘Register’ view and a ‘Login’ view.
* If the user is logged in display their First and Last name on the page somewhere.
* If the user is an administrator display a link to the ‘AddBlogPost’ view. 
* Layout file will contain my First Name, Last Name, Email Address and Student Number in the footer.

2.	 Home Controller / Register
* This view will allow users to create ‘User’ accounts to be stored in database. 
* Create a form that creates a User model: FirstName, LastName, EmailAddress, Password and Role
* Once data have been collected from the client, it will get stored in the database and redirect the user to the Login view

3.	Home Controller / Login
* This view will allow the users to log in to your application.
* Create a form that accepts the users email address and password.
* Once the form is submitted authenticate the user. If the user is valid redirect them to the ‘Index’ view

4.	Home Controller / Index
* This view will list all the BlogPosts 
* It will display ‘Title’, the first 100 characters of the ‘Content’ as a preview and the ‘Posted’ fields from each BlogPost object in the database
* The Title of each blog post will be a link to the ‘DisplayFullBlogPost’ view
* If the user is logged in as an administrator each blog post will display a link to the ‘EditBlogPost’ view as well as the other requirements above.
5.	Home Controller / DisplayFullBlogPost
* This view will list the Title, the Content, the Posted value, the email address and full name of the users who created the post.
* If the user is logged in they should be able to comment on the blog post using a comments text box at the bottom of the screen. 
* Display all comments associated with the blog post.
6.	Home Controller / AddBlogPost
* This view will collect the data needed to create a blog post. 
* Use a form to collect Title, Content, Posted (date time)
7.	Home Controller / EditBlogPost
* This view will allow an administrator to modify the data of a selected blog post.
* Use a form to collect the modified Title, Content, Posted (date time) content.
