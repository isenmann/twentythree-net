# TwentyThree.Net

The TwentyThree.Net API Library is a .Net Library for accessing the 23 (http://www.23hq.com) API. This library is still under development but should work with the most methods of the 23 API. 
It is written entirely in C# and it's heavily based on Flickr.Net from Sam Judson (https://github.com/samjudson/flickr-net). Thanks for the good work on flickr-net.

I have modified his version and deleted all references to Flickr and Zoomr. FlickrNet contains code to connect to 23, but 
there are lots of URLs which are hardcoded to Flickr and also Flickr.Net is changing to OAuth which 23 doesn't support. So
I have decided to fork his repository and to change the library in a way that it only supports 23 and this as good as possible.

The library provides a simple one-to-one mapping to the methods of the 23 REST API, 
hopefully hiding all of the complexity of calling the API, especially when it comes to authentication. 
Check the 23 API web site for the full list of commands, and then use the corresponding method in the 23 library, 
e.g. to call flickr.photos.search use the TwentyThree.PhotosSearch method.

The library is not an attempt to provide an ORM layer over the 23 API, 
e.g. if you retrieve a list of photosets for a user (i.e. by calling TwentyThree.PhotosetsGetList) 
there is no direct property on each photoset to get the photos for that set, 
you must go back to the 23 object and call TwentyThree.PhotosetsGetPhotos passing in the photoset id.

# Examples

You can create a new instance of the TwentyThree class, and set its properties, or you can use one of the parameterised constructors:

~~~
TwentyThree twentythree = new TwentyThree();
twentythree.ApiKey = myApiKey;
~~~
or
~~~
TwentyThree twentythree = new TwentyThree(myApiKey);
~~~

The simplest method (although it has the most parameters) is probably the PhotosSearch method, 
which is best used by passing in a PhotoSearchOptions instance:

~~~
var options = new PhotoSearchOptions { Tags = "colorful", PerPage = 20, Page = 1 };
PhotoCollection photos = twentythree.PhotosSearch(options);

foreach(Photo photo in photos) 
{
  Console.WriteLine("Photo {0} has title {1}", photo.PhotoID, photo.Title);
}
~~~

## Photo Extras
One of the hardest things to understand initially is that not all properties are returned by 23, you have to explicity request them.  
For example the following code would be used to return the Tags and the LargeUrl for a selection of photos:
~~~
var options = new PhotoSearchOptions { 
  Tags = "colorful", 
  PerPage = 20, 
  Page = 1, 
  Extras = PhotoSearchExtras.LargeUrl | PhotoSearchExtras.Tags 
};

PhotoCollection photos = twentythree.PhotosSearch(options);
// Each photos Tags and LargeUrl properties should now be set, 
// assuming that the photo has any tags, and is large enough to have a LargeUrl image available.
~~~

# License

The project is licensed under both the LGPL 2.1 license, and the Apache 2.0 license. 
This gives you the flexibility to do pretty much anything you want with the code. Enjoy!

# Contact

You can contact me via email, which is public on my profile page here on github or start a discussion for this project.

See my 23 homepage at http://www.23hq.com/ise_80

# Donations

If you want to support me, you can donate at: https://www.paypal.me/danielisenmann
