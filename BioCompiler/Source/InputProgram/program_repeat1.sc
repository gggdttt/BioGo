# this is a demo

# droplet declaration
droplet d1;
droplet d2;

# droplet input
input(d1,1,1,1.0);
input(d2,4,4,0.5);


repeat 10 times{
move(d1,3,3);
move(d2,7,7);
move(d1,5,5);
move(d2,10,10);
}

# output
output(d1,0,0);
output(d2,0,0);

