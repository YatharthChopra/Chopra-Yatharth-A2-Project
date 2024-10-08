using System;

namespace Game10003
{
    public class Game
    {
        // Predefined colors for the house, trees, and door when clicked
        Color houseColor = Color.Red;
        Color treeColor = new Color(150, 75, 0);
        Color leafColor = Color.Green;

        // No color for initial state 
        Color noColor = new Color(255, 255, 255, 0);

        // Define colors that will be applied on clicks
        Color clickedHouseColor = Color.Red;
        Color clickedTreeTrunkColor = new Color(92, 64, 51);
        Color clickedLeafColor = new Color(144, 238, 144);
        Color clickedRoofColor = new Color(150, 75, 0);
        Color clickedDoorColor = new Color(54, 69, 79);

        // Booleans to track if shapes are clicked
        bool isHouseClicked = false;
        bool isLeftTreeClicked = false;
        bool isRightTreeClicked = false;
        bool isRoofClicked = false;
        bool isDoorClicked = false;
        bool isLeftLeavesClicked = false;
        bool isRightLeavesClicked = false;

        public void Setup()
        {
            Window.SetSize(800, 600);
            Console.WriteLine("You can Reset the code using the Keyboard input by pressing the Letter R at any given point of time in the code");
        }

        public void Update()
        {
            Window.ClearBackground(new Color(173, 216, 230));

            // Check for reset input (pressing the "R" key)
            if (Input.IsKeyboardKeyPressed(KeyboardInput.R))
            {
                ResetColors();
            }

            // Get the mouse position
            float mouseX = Input.GetMouseX();
            float mouseY = Input.GetMouseY();

            // Main objects of the program
            DrawHouse(293, 280, mouseX, mouseY);
            DrawTree(160, 280, mouseX, mouseY, "left"); // Left tree
            DrawTree(573, 280, mouseX, mouseY, "right"); // Right tree
        }

        // Function to reset all click states
        private void ResetColors()
        {
            isHouseClicked = false;
            isLeftTreeClicked = false;
            isRightTreeClicked = false;
            isRoofClicked = false;
            isDoorClicked = false;
            isLeftLeavesClicked = false;
            isRightLeavesClicked = false;
        }
        // Function to draw a house
        private void DrawHouse(int x, int y, float mouseX, float mouseY)
        {
            if (IsMouseHoveringOverRect(mouseX, mouseY, x, y, 200, 120) &&
                !IsMouseHoveringOverRect(mouseX, mouseY, x + 80, y + 40, 40, 80) &&
                Input.IsMouseButtonPressed(MouseInput.Left))
            {
                isHouseClicked = true;
                Console.WriteLine("You just colored the house frame in Red Color!");
            }

            if (isHouseClicked)
            {
                Draw.FillColor = clickedHouseColor;
            }
            else
            {
                Draw.FillColor = noColor;
            }

            // base of the house
            Draw.Rectangle(x, y, 200, 120);

            // Roof click detection and coloring
            if (IsMouseHoveringOverRect(mouseX, mouseY, x, y - 80, 200, 80) && Input.IsMouseButtonPressed(MouseInput.Left))
            {
                isRoofClicked = true;
                Console.WriteLine("You just colored the roof in Brown Color!");
            }

            if (isRoofClicked)
            {
                Draw.FillColor = clickedRoofColor;
            }
            else
            {
                Draw.FillColor = noColor;
            }

            // Draw the roof (triangle)
            Draw.Triangle(x, y, x + 100, y - 80, x + 200, y);

            // Door click detection and coloring
            if (IsMouseHoveringOverRect(mouseX, mouseY, x + 80, y + 40, 40, 80) && Input.IsMouseButtonPressed(MouseInput.Left))
            {
                isDoorClicked = true;
                Console.WriteLine("You just colored the door in Light Grey Color!");
            }

            if (isDoorClicked)
            {
                Draw.FillColor = clickedDoorColor;
            }
            else
            {
                Draw.FillColor = noColor;
            }

            // Draw the door (rectangle)
            Draw.Rectangle(x + 80, y + 40, 40, 80);
        }

        // draw trees 
        private void DrawTree(int x, int y, float mouseX, float mouseY, string side)
        {
            bool isTreeClicked = false;
            bool isLeavesClicked = false;

            if (side == "left")
            {
                isTreeClicked = isLeftTreeClicked;
                isLeavesClicked = isLeftLeavesClicked;
            }
            else if (side == "right")
            {
                isTreeClicked = isRightTreeClicked;
                isLeavesClicked = isRightLeavesClicked;
            }

            // Tree trunk click detection and coloring
            if (IsMouseHoveringOverRect(mouseX, mouseY, x, y, 40, 120) && Input.IsMouseButtonPressed(MouseInput.Left))
            {
                if (side == "left")
                {
                    isLeftTreeClicked = true;
                    Console.WriteLine("You just colored the left tree trunk in Brown Color!");
                }
                else if (side == "right")
                {
                    isRightTreeClicked = true;
                    Console.WriteLine("You just colored the right tree trunk in Brown Color!");
                }
            }

            if (isTreeClicked)
            {
                Draw.FillColor = clickedTreeTrunkColor;
            }
            else
            {
                Draw.FillColor = noColor;
            }

            // tree trunk (rectangle)
            Draw.Rectangle(x, y, 40, 120);

            // Tree leaves click detection and coloring 
            if (IsMouseHoveringOverCircle(mouseX, mouseY, x + 20, y - 60, 60) && Input.IsMouseButtonPressed(MouseInput.Left))
            {
                if (side == "left")
                {
                    isLeftLeavesClicked = true;
                    Console.WriteLine("You just colored the left tree leaves in Light Green Color!");
                }
                else if (side == "right")
                {
                    isRightLeavesClicked = true;
                    Console.WriteLine("You just colored the right tree leaves in Light Green Color!");
                }
            }

            if (isLeavesClicked)
            {
                Draw.FillColor = clickedLeafColor;
            }
            else
            {
                Draw.FillColor = noColor;
            }

            // tree leaves (circle)
            Draw.Circle(x + 20, y - 60, 60);
        }

        private bool IsMouseHoveringOverRect(float mouseX, float mouseY, float rectX, float rectY, float width, float height)
        {
            return mouseX > rectX && mouseX < rectX + width && mouseY > rectY && mouseY < rectY + height;
        }

        private bool IsMouseHoveringOverCircle(float mouseX, float mouseY, float circleX, float circleY, float radius)
        {
            float distX = mouseX - circleX;
            float distY = mouseY - circleY;
            float distance = MathF.Sqrt(distX * distX + distY * distY);

            return distance < radius;
        }
    }
}