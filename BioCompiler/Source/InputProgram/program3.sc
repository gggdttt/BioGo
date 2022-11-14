# this is a simple demo

# droplet declaration
droplet d1;
droplet d2;

# droplet input
input(d1,1,1,1.0);
input(d2,4,4,0.5);


# move
move(d1,3,3);
move(d2,7,7);


# mixing
mix(d2,2,2,2,2,5);

# store
store(d2,5,5,2.0);

# output
output(d1,0,0);
output(d2,0,0);