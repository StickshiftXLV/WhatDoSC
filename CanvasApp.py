import tkinter as tk
from tkinter import filedialog

def clear_canvas(canvas, text_widget):
    canvas.delete("all")
    text_widget.delete("1.0", tk.END)


def paint(event, canvas):
    x, y = event.x, event.y
    canvas.create_oval(x - 2, y - 2, x + 2, y + 2, fill="black", outline="black")


def create_notepad():
    app = tk.Tk()
    app.title("Notepad with Drawing Canvas")

   
    canvas = tk.Canvas(app, width=700, bg="#d5db8a")  # Canvas for drawing
    canvas.pack()

    canvas.bind("<B1-Motion>", lambda event: paint(event, canvas))     # Bind mouse motion to drawing


  
    text_widget = tk.Text(app, wrap="word", bg = "#e2e6bc" , height=10)   # Text widget for typing
    text_widget.pack()

  

    btn_clear = tk.Button(app, text="Clear", command=lambda: clear_canvas(canvas, text_widget))
    btn_clear.pack(side=tk.RIGHT, padx=10, pady=5)

    app.mainloop()


if __name__ == "__main__":
    create_notepad()
