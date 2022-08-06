# ExtensionsLibrary
A library with helper functions for my work

#How to Use

1. The Guid Validator: To curb the issues I had at work where a user consuming an api could send a default guid or a sample guid which does not exist, 
you just need to slap validation attribute: "[GuidValidator]" to use .Net middleware to validate guids as required and non-default.

2. The MailValidator in the Utilities.ValidateMail.IsValidEmail uses regex to strip an email string and validates if the email is valid or not. If valid returns true.

3. The SaveFiles class has both the ByteArrayToFile, FileToByte streaming which can be translated to a blob url using File http attribute in your controller, 
The fileToBase64 streamer

4. The GenerateRandomNtokens. It is a cryptographically pseudo-random generator I use for generating tokens, otp etc. Available with ascii and numeric.
