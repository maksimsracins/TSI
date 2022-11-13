#include<Windows.h>
#include <GL/glut.h> /*Для Linux и Windows*/
#include<vector>
#include<fstream>
#include<iostream>

using namespace std;
struct Point
{
	int x, y;
};
void reshape(int w, int h);
void display();
void readFromFile();
void lineto(Point p);
void moveto(Point p);
void processSpecialKeys(int key, int x, int y);
void processNormalKeys(unsigned char key, int x, int y);

vector<Point> point;
vector<int>code;
Point currentPoint;


int main(int argc, char* argv[])
{
	currentPoint.x = 0; currentPoint.y = 0;
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(800, 600);
	glutInitWindowPosition(100, 150);
	glutCreateWindow("OpenGL lesson 4_2");
	glutDisplayFunc(display);
	glutReshapeFunc(reshape);
	glutKeyboardFunc(processNormalKeys);
	glutSpecialFunc(processSpecialKeys);
	glutMainLoop();
	return 0;
}
void reshape(int w, int h)
{
	glViewport(0, 0, w, h);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0, 150, 0, 100); //left, right, bottom, top
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
}
//вырисовка
void display() {
	glClearColor(1, 1, 1, 0);
	glClear(GL_COLOR_BUFFER_BIT);
	glColor3f(0, 0, 0);
	readFromFile();
	glColor3d(1, 0, 0);
	cout << code.size();
	for (int i = 0; i < code.size(); i++) {
		if (code[i] <= 0)
		{
			moveto(point[i]);
		}
		else
		{
			lineto(point[i]);
		}
	}
	glFlush();
}
void readFromFile() {
	fstream f("points.txt", ios::in);
	int pointNumber;
	int x, y; Point p;
	f >> pointNumber;
	for (int i = 0; i < pointNumber; i++) {
		f >> p.x >> p.y;
		point.push_back(p);
	}
	int movesNumber, m;
	f >> movesNumber;
	for (int i = 0; i < movesNumber; i++) {
		f >> m; code.push_back(m);
	}
	f.close();
}

void processNormalKeys(unsigned char key, int x, int y)
{
	if (key == 27)
		exit(0);
	if (key == 65)
	{
		glMatrixMode(GL_MODELVIEW);
		glTranslated(20, 20, 0);
		display();
	}
}

void processSpecialKeys(int key, int x, int y) {
	int iteration = 0.2;
	switch (key) {
	case GLUT_KEY_UP:
		glMatrixMode(GL_MODELVIEW);
		glTranslated(0, 20, 0);
		display();
		break;
	case GLUT_KEY_DOWN:
		glMatrixMode(GL_MODELVIEW);
		glTranslated(0, -20, 0);
		display();
		break;
	case GLUT_KEY_LEFT:
		glMatrixMode(GL_MODELVIEW);
		glTranslated(-20, 0, 0);
		display();
		break;
	case GLUT_KEY_RIGHT:
		glMatrixMode(GL_MODELVIEW);
		glTranslated(20, 0, 0);
		display();
		break;
	case GLUT_KEY_PAGE_UP:
		glMatrixMode(GL_MODELVIEW);
		glRotatef(90, 0, 1, 0);
		glPushMatrix();
		display();
		break;
	}
}

void moveto(Point p) {
	currentPoint.x = p.x; currentPoint.y = p.y;
}

void lineto(Point p) {
	glBegin(GL_LINES);
	glVertex2i(currentPoint.x, currentPoint.y);
	glVertex2i(p.x, p.y);
	glEnd();
	currentPoint.x = p.x; currentPoint.y = p.y;
}