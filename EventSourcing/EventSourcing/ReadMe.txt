http://www.cqrs.nu/tutorial/cs/01-design

Events
TabOpened
DrinksOrdered
FoodOrdered
DrinksCancelled
FoodCancelled
DrinksServed
FoodPrepared
FoodServed
TabClosed

Commands
OpenTab
PlaceOrder
AmendOrder
MarkDrinksServed
MarkFoodPrepared
MarkFoodServed
CloseTab

Exceptions
CannotCancelServedItem
TabHasUnservedItems
MustPayEnough

Agregates
TAB
