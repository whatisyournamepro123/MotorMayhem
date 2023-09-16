import nltk
from nltk.chat.util import Chat, reflections

# Define some patterns and responses
patterns = [
    (r'hi|hello|hey', ['Hello!', 'Hi there!', 'Hey!']),
    (r'how are you', ['I am good, thanks!', 'I am doing well.']),
    (r'(.*) your name', ['I am a chatbot.']),
    (r'(.*) (good|well)', ['That\'s great to hear!']),
    (r'(.*) (bad|sad)', ['I\'m sorry to hear that.']),
    (r'quit', ['Bye!', 'Goodbye!']),
]

# Create a Chat instance
chatbot = Chat(patterns, reflections)

# Start the conversation
print("Bot: Hi, I'm your assistant. How can I help you today?")
while True:
    user_input = input("You: ")
    if user_input.lower() == 'quit':
        break
    else:
        response = chatbot.respond(user_input)
        print(f"Bot: {response}")
