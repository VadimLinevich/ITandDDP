# Game Web App
## Mock up:
Figma: https://www.figma.com/proto/X0y2c7InKmojkVCHqapLC5/ManePage?page-id=0%3A1&node-id=7-17&viewport=47%2C4241%2C0.14&scaling=min-zoom
## Main Functions
- Sign in  
  Method — "POST"  
  Params — email ___string___, password ___string___  
  Returns a response to a login request 
- Get games by grade
  Method — "GET"  
  Params — grade ___number___  
  Returns a list of top games.  
- Get games by date
  Method — "GET"  
  Params — date ___string___  
  Returns a list of latest games. 
- Get games by genre
  Method — "GET"  
  Params — genre_name ___string___  
  Filter games by genre.
- Add review  
  Method — "POST"  
  Params — userId ___number___, gameId ___number___, content __string__, grade ___number___, date __string__  
  Returns the result of the request.
- Get reviews by date
  Method — "GET"  
  Params — date ___string___  
  Returns a list of reviews. 
- Get games by name(search field)   
  Method — "GET"   
  Returns a list of games. 
## Data Models

### User info
Info about user
- id ___number___
- nickname ___string___
- email ___string___
- password ___string___

### Game data
Info about game
- id ___number___
- title ___string___
- poster ___string___
- description ___string___
- date ___string___
- developer ___string___
- publisher ___string___
- rating ___string___
- trailer ___string___

### Genre data
Info about game
- id ___number___
- name ___string___

### Review data
Info about game
- UserId ___number___
- GameId ___number___
- grade ___number___
- content ___string___
