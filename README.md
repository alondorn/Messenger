# Unity Event Messenger
This is an event messaging system for C# Unity projects. Some times called "Message Bus".

Define the AppEvents enum according to your Events,
Use Messenger.Subscribe(AppEvents eventType, UnityAction<string> listener) to register any action to an event from anywhere,
Use Messenger.Execute(AppEvents eventType, string message) to publish any event.
