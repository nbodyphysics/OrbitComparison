# OrbitComparison
Unity project comparing methods for computing orbits

This is the code used to generate the videos used in the blog post at nbodyphysics.com

In the OrbitComp scene four orbit evolutions are presented:
- Unity's AddForce
- Euler
- Semi-Implicit Euler
- Leapfrog

The initial conditions are set by the InitialConditions object in the scene. These are applied to all four objects. 

There is a second camera view showing energy (which should be constant). This is used to assess the accuracy of the 
integration methods. 

The code has not been optimized or polished. 

