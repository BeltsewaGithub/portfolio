public class Elevator {
    private int currentFloor = 1;
    private final int minFloor;
    private final int maxFloor;

    public Elevator(int minFloor, int maxFloor) {
        this.minFloor = minFloor;
        this.maxFloor = maxFloor;
    }

    public int getCurrentFloor() {
        return currentFloor;
    }

    public void moveDown() {
        currentFloor = currentFloor > minFloor ? currentFloor - 1 : currentFloor;
    }

    public void moveUp() {
        currentFloor = currentFloor < maxFloor ? currentFloor + 1 : currentFloor;
    }

    public void move(int floor) {
        if (floor <= maxFloor && floor >= minFloor) {
            this.currentFloor = floor;
            System.out.println("Вы на " + currentFloor + " этаже");
        } else {
            currentFloor = currentFloor;
            System.out.println("error :(");
        }

    }
}


