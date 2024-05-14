import tkinter as tk
import time

def insert_alphabet():
    text_field.delete(1.0, tk.END)  # Clear the text field before inserting
    start_time = time.time()
    for letter in 'abcdefghijklmnopqrstuvwxyz':
        text_field.insert(tk.END, letter + ' ')
        text_field.update()  # Update the GUI to reflect the changes
    end_time = time.time()
    elapsed_time = end_time - start_time
    result_label.config(text=f"Total time taken: {elapsed_time:.4f} seconds")

# Create the main window
root = tk.Tk()
root.title("Typing Assist Program Benchmark")

# Create a larger Text widget
text_field = tk.Text(root, height=10, width=50, wrap=tk.WORD)
text_field.pack(pady=10)

# Create a button to start the insertion
start_button = tk.Button(root, text="Start Insertion", command=insert_alphabet)
start_button.pack(pady=10)

# Create a label to display the result
result_label = tk.Label(root, text="")
result_label.pack(pady=10)

# Run the Tkinter event loop
root.mainloop()
