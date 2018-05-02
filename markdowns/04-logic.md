# Conditional Logic in C#

## Basics

C# conditional logic is based on the `boolean` type, which can be either `true` or `false`.
Conditional operations are evaluated in the execution flow, and supports multiple operators:

* Equality operators: `==` and `!=`
* Binary operators! 
  * AND: `x && y`
  * OR: `x || y`
  * XOR: `x ^ y`
* Unary operator NOT : `!x`

When using binary operations, the right part is evaluated only if necessary.

Execution flow can be controlled using structures and branching conditions:

**Branching**

```C#
if (condition) 
{ ... } 
else if (other condition) 
{ ... } 
else 
{ ... }
```

**Loops**

```C#
for(int i = 0; i < end; i++)
{
    ...
}

while(condition)
{
    ...
}

do
{
    ...
} while(condition)
```

## Guidelines to make your code readable

When developing complex applications, branching conditions and tests can quickly become complicated and hard to read for any developer.

This is especially true when new developers join a team working on a project, the time required to understand the code base is very dependant on the readability of the code, that's why you should try to organize your code to make it as readable as possible.

When doing complex condition testing and branching, try to extract methods corresponding to parts of your tests to make it easier to understand your intention.

**Example**

```C#
if(user.GetUserGroups().Contains(ADMIN_GROUP) || (user.GetRights().Contains(CAN_EDIT_PAGE) && page.GetAuthors().Contains(user.Id)))
{
    ...
}
```

We can extract two methods here to make it more readable

```C#
var userIsAdmin = user.GetUserGroups().Contains(ADMIN_GROUP);
var userCanEditPage = user.GetRights().Contains(CAN_EDIT_PAGE) && page.GetAuthors().Contains(user.Id);

if(userIsAdmin || userCanEditPage)
{ 
    ...
}
```