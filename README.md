# A C# code verification test

***Unit tests to be added***

## Task
Write a web application with an endpoint to search a list of words given a prefix

Endpoint name: Stem

Param: stem

Example: /stem?stem=abcd

* The return must have the following format: { "data": ["abcd", "abcde", "abcdef"] }
* The status code must be 200 if data is found
* The staus code must be 404 if no words is found
* Source deta must come from "https://raw.githubusercontent.com/dwyl/english-words/master/words_alpha.txt"
* If no value for the param stem is provided, return all the words on the list
* Think on performance

## Solution

* A service was created to retrieve the list of words from the source provided
* The service implements an interface, so it can be replaced for another implementation if source is changed
* The service is registered as a singleton of the application so it will retrieve data only once.
