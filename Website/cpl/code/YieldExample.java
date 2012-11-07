import java.util.Iterator;

public class YieldExample {

    public Iterator<Integer> Fibonacci () {
        return new FibonacciEnum();
    }

    private class FibonacciEnum implements Iterator<Integer> {

        int state = -1;
        int a = 0, b = 1, c;

        public boolean hasNext() {
            return true;
        }

        public Integer next() {
            if(state <= 0) {
                state++;
                if(state == 0) {
                    return 1;
                }
            }
            else {
                a = b;
                b = c;
            }
            c = a+b;
            return c;
        }

        public void remove() {
            throw new UnsupportedOperationException("Not supported yet.");
        }

    }

    public static void main(String [ ] args) {
        YieldExample ye = new YieldExample();
        Iterator<Integer> fib = ye.Fibonacci();
        int n = 0;
        while(fib.hasNext() && n < 10) {
            System.out.println(fib.next());
            n++;
        }
    }

}
