# Checking different algorithms and data structures for performance.
## This [repository](https://github.com/dkoleev/PerformanceTestingInUnity) contains examples of tests in unity.

Characteristics of the computer on which the measurements were taken:
![](https://github.com/dkoleev/PerformanceTesting/blob/master/Content/Images/pc_characteristic.png)

## 1. Experiments with the CPU cache.
### How data locality affects performance.
These examples deal with spatial locality (there is also temporal locality).
### A little theory before we look at examples.
The [presentation](https://docs.google.com/presentation/d/1zKsVoWUkBRu50UW5VW505fWX-KwT3m5T3WY_SnTajcs/edit?usp=sharing) clearly describes how modern memory and processors are constructed.
So, what we need to know about the computer in order to write optimized programs:
+ To start calculations processor does not get data from memory directly but loads data from it into its cache and from cache into registers (in brief why - the cache is based on SRAM technology (fast but expensive), the main memory is based on DRAM (slow but cheap)).
+ The processor cache usually consists of several cache levels (in some levels the cache is split between cores). The higher the level, the higher the data retrieval speed from it and the smaller its size.
+ Data from main memory is read into the cache not byte-by-byte, but by chunks whose size is usually 64 bytes (so called cache lines)

#### Example 1.
There is an array:
``` 
int[] arr = new int[64 * 1024 * 1024];
```
Two examples, in the first we run through every 16th element, and in the second through every first element:
```
for (int i = 0; i < arr.Length; i += 16)
  arr[i] *= 3;
 
for (int i = 0; i < arr.Length; i++) 
  arr[i] *= 3;
  ```
  It can be assumed that the first cycle will work faster, but as measurements show, both cycles take almost the same number of CPU cycles (measurements conducted by the program [vTune](https://software.intel.com/en-us/vtune)).
  ![](https://github.com/dkoleev/PerformanceTesting/blob/master/Content/Images/result_1.png) 
  <br>
  This example clearly shows that the main time is spent not on calculations, but on getting data from memory.
  <br>
  #### Example 2.
  There is a two-dimensional array:
  ```
  protected static int[,] Matrix;
  ```
  In the first case, we run through the lines:
  ```
       public override void Run(int cicles)
        {
            for (int c = 0; c < cicles; c++)
            {
                var sum = 0;
                for (int i = 0; i < MaxSize; ++i)
                    for (int j = 0; j < MaxSize; ++j)
                        sum += Matrix[i, j];
            }
        }
 ```
In the second example, we run through the columns:
 ```
  public override void Run(int cicles)
        {
            for (int c = 0; c < cicles; c++)
            {
                var sum = 0;
                for (int i = 0; i < MaxSize; ++i)
                    for (int j = 0; j < MaxSize; ++j)
                        sum += Matrix[j, i];
            }
        }
```
The result when you run through the rows:
<br>
![](https://github.com/dkoleev/PerformanceTesting/blob/master/Content/Images/res_2.png)
<br>
The result when you run through the columns:
<br>
![](https://github.com/dkoleev/PerformanceTesting/blob/master/Content/Images/res_column.png)
<br>
In these measurements, we should pay attention only to the Memory Bound indicator. As we can see the performance is more than twice as high when passing through the rows. Also, if you look at the graphs, we see that the bottleneck in our case is the third level cache 39.3%, then comes the main memory 14.6%.
<br>
Why was the third level cache the bottleneck and not the main memory? Because the amount of data on which the measurements were made is placed in the third level cache. Therefore, also the difference in speed is not so different, because access to the third level cache is much faster than to the main memory.
<br>
This example clearly shows the importance of sequential location and reading data from memory. Because data from memory and from one cache level to another is read not byte-by-byte but by cache lines, when reading data by columns, the caches get clogged with useless data which do not participate in calculations and, consequently, get clogged faster, which leads to necessity of requesting data from slower memory more often.
<br>
![](https://github.com/dkoleev/PerformanceTesting/blob/master/Content/Images/row_column.png)
<br>
In the end, it all comes down to one simple thought:
<br>
### When the processor performs a read from memory, it reads an entire line of cache. The more useful data we put in that cache line, the faster we will get. So our goal is to organize our data structures so that the things we process are in memory one by one.


## hot/cold splitting.
Even in a situation where we have data in a linear data array and the number of cache misses is minimal, we may still have data inside an entity that we use very rarely, but it is constantly loaded into the cache. As a result, each entity increases and the number of entities that fit in the cache line decreases. To solve this problem, there is a cold/hot split method.
The idea is to divide the data into two parts. The first stores the "hot" data: the states that we use on every frame. The second stores the "cold" data: everything else that is used much less frequently.
The hot part is the backbone of the entity, you have data that we use all the time in the logic and store in the entity itself to avoid a pointer race.
The cold part is something we rarely refer to. We keep a reference to it in the main part, i.e., we link it to the entity by means of composition (Pattern Strategy).
