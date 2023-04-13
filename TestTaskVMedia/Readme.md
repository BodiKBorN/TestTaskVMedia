# Assignment 2. .Net application

•	Write a "proxy" that will return the modified text of reddit.com (or any other site of your choice);
•	To each word, which consists of six letters, you must add a symbol "™";
•	You can use any .Net technology and libraries in the C# language;
•	The functionality of the original site must not be altered;
•	All internal navigation links of the site must be replaced by the address of the proxy-server.

That is, site navigation must be handled by a Proxy without taking the client back to the original site.

Example. A request to, say, {proxy address}/r/popular/ should show the content of the page
https://www.reddit.com/r/popular/ with changed words that were 6 characters long.
And all the site navigation to sections of the site should go through Proxy.
Hint: There is no SLOC limit for your solution. But, if your proxy solution contains more than 300 SLOC, then probably you do something wrong. 
