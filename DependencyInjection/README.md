1. UI Presentation
2. Benefits:
	- loos cupling 
		- parallel development - less cupling, less files to change, less conflicts
		- building blocks, all dimensions (replace, decorate etc.)
3. Theoretical Problems:
	- seperation of concerns (OK) / thight cupling (NOT OK)
	- new is glue: compile time reference, responsibility for lifetime of this object
	- if you think that lifetime management is more seriuos that compile time reference look at this:
		- View coupled to VM -> VM coupled to ... = View coupled to Services
		- you need to compile everything when you want to run/test/compile UI
	- how to test services?
4. Example of Problems:
	- use different service
	- use caching (now you need to create caching service for all new services)
	- test it (now which service should I use in ViewModel tests?)
5. Solutions:
	- interface + plugins with other data sources (possibly other ABB dlls)
	- decorator
	- moqs

Code based on http://www.jeremybytes.com/Demos.aspx#DI
