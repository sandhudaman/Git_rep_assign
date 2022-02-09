import time
import numpy as np
import random
import pandas as pd

player  = input("How many players? ")
interval = input("How many time intervals? ")
print("Enter " + player + " names")
playerarr = []

while len(playerarr) < int(player):
    x = input()
    x = x.replace(' ', '')
    x = x.lower()
    if not(x  == ''):
        if x not in playerarr:
            playerarr.append(x)
        else:
            print('name already enterd')

caplayer = [x.capitalize() for x in playerarr]
ranchecker = []
t1 = []
t2 = []
m = []

while not(len(caplayer) == len(ranchecker)):
    play = random.choice(caplayer)
    if play not in ranchecker:
        print(play +"'s turn. Press enter "+ interval + " times quickly")
        for y in range(int(interval)):
            time1 = time.time()
            input()
            time2 = time.time()
            t2.append(round(time2-time1, 3))
            
        t1.append(t2)
        ranchecker.append(play)
        t2 = []

r1 = np.array(ranchecker)
r2 = np.array(t1)
r2 = np.transpose(r2)
rdata = np.row_stack((r1,r2))

mmean = np.round(np.mean(rdata[1:,:].astype(float),axis = 0),3)
nameAndMean = np.row_stack((r1,mmean))

names = sorted(rdata[0,:])
print("Names:", names)
print("Mean:",mmean)

min_mmmean = np.min(mmean)
k= np.where(mmean == min_mmmean)
print("Fastest Average Time: " +  str(min_mmmean) +" by " + str(r1[k[0]]))


max_mmmean = np.max(mmean)
i = np.where(mmean == max_mmmean)
print("Slowest Average Time: " +  str(max_mmmean) +" by " + str(r1[i[0]]))

min_val = np.min(r2)
l = np.where(r2 == min_val)
print("Fastest Single Time: " +  str(min_val) +" by " + str(r1[l[0]]))

max_val = np.max(r2)
m = np.where(r2 == max_val)
print("Slowest Single Time: " +  str(max_val) +" by " + str(r1[m[0]]))


print(rdata)



