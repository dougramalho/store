# store
The purpose of this repository is to consolidate my knowledge of architectures, frameworks, and standards.

To get his done I will apply DDD to create a web store. What I want is to have a complex app where I can try all kind of stuff, for example, I can build a client-side with "react" (and I will do in this beginning) and change to Angular, Vue or typescript. Another example is to create the first version without Event Sourcing and add this feature later, or change everything on the server side to python with the Tornado, my willingness to try new things will be powered.

The store will have all the basic features that a store should have, like searching for products, filters, adding to the cart and making the purchase.

DDD will guide the design of the architecture, and at this very initial point, my dev stack will be:

* Asp.net Core
* Restful Web API
* React as the SGP
* Elasticsearch 

My initial goal is: Create a Store App using DDD with the related dev stack.

Everything can change, and I will make this repo as a big dev diary, and today (04/20/2018) I do not know how it will end but will be very funny.

# About the store
In a regular DDD development, we have the Domain Expert. This guy is one of the most important guys ever because he/she is the person who knows everything about the problem that we might to transport to the software world. I know... we can have a lot of domain experts, each one focused in one specific area. One of the central points is to bring the domain experts to the team, and together, with their knowledge about the business, and our in IT, create a masterpiece.

My initial play was to select one friend and put him in the role of client, but it didn't succeed because of the agenda for interviews never fitted (I tried to force with beer, but always we ended tipsy kkk).

So, I will be the domain expert at this point, it's far away from the best scenario, but we need to solve this little problem.

* The users don't need to be logged in to browse the catalog
* The users can type some text to search products
* When filtered, the results should be displayed with options to see the details or directly add to carts 
* The users can add products to their cart at the result page or details page
* The users can see on any page the cart total
* Every page must show a button to proceed to checkout
* The checkout page must show the products on the cart, the total and options to increase or decrease the amount of each good
* the user needs to inform the shipping details before the payment
* The store needs to verify that the user is logged in, and allow to register to finalize the purchase
* After filling the payment, the store will send an e-mail with the order and finalize the purchase

