import com.skillbox.airport.Airport;
import com.skillbox.airport.Flight;

import java.time.Instant;
import java.time.LocalDateTime;
import java.time.ZoneOffset;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;


public class Main {
    public static void main(String[] args) {
    }

    public static List<Flight> findPlanesLeavingInTheNextTwoHours(Airport airport) {
        List<Flight> planesLeavingInTheNextTwoHours =  new ArrayList<>();

        LocalDateTime nowPlus2Hours = LocalDateTime.now().minusHours(1);
        Instant instantNowPlus2Hours = nowPlus2Hours.toInstant(ZoneOffset.UTC);
        Date nowPlus2Hour = Date.from(instantNowPlus2Hours);
//
//        airport.getTerminals().forEach(terminal -> terminal.getFlights().forEach(flight -> {
//            if ( flight.getDate().before(nowPlus2Hour) && flight.getDate().after(new Date())
//                    && flight.getType().equals(Flight.Type.DEPARTURE) ) {
//                planesLeavingInTheNextTwoHours.add(flight);
//            }
//        }));


        //stream API version
        List<Flight> flights = new ArrayList<>();
        airport.getTerminals().forEach(terminal -> terminal.getFlights().forEach(flight -> flights.add(flight)));
        flights.stream().filter(flight -> (flight.getDate().before(nowPlus2Hour) &&
                        flight.getDate().after(new Date()) &&
                        flight.getType().equals(Flight.Type.DEPARTURE))).forEach(planesLeavingInTheNextTwoHours::add);

        return planesLeavingInTheNextTwoHours;
    }

}