#if defined(linux) || defined(_WIN32)
#include <GL/glut.h>    /*Äëÿ Linux è Windows*/
#else
#include <GLUT/GLUT.h>  /*Äëÿ Mac OS*/
#endif

int xIt = 0.1, yIt = 0.1, zIt = 0.1;

void reshape(int w, int h);
void display();
void processNormalKeys(unsigned char key, int x, int y);
void processSpecialKeys(int key, int x, int y);
void drawXYZ();

int main(int argc, char* argv[])
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGBA);

	glutInitWindowSize(800, 600);
	glutCreateWindow("OpenGL lesson 6");
	glutReshapeFunc(reshape);
	drawXYZ();
	glutDisplayFunc(display);
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
	//glOrtho(-10, 10, -10, 10, -10, 10);
	gluPerspective(60, 1, 0, 20);
	gluLookAt(0, 0, 10, 0, 0, 0, 0, 1, 0);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	glClearColor(1, 1, 1, 0);
}

void display()
{
	glClear(GL_COLOR_BUFFER_BIT);
	glColor3f(1.0, 0.0, 0.0);

	glutWireTeapot(5);
	drawXYZ();
	glutSwapBuffers();
}

void processNormalKeys(unsigned char key, int x, int y)
{
	if (key == 27)
		exit(0);
	if (key == '+') {

		glScalef(1.1+xIt, 1.1+yIt, 1);
		display();

		xIt = xIt + 0.1;
		yIt = yIt + 0.1;
	}
	if (key == '-') {

		glScalef(1*0.9, 1*0.9, 1);
		display();
	}
	if (key == 127) {

		glRotatef(90, 1, 400, 0);
		display();
	}
}

void processSpecialKeys(int key, int x, int y) {
	switch (key) {
	case GLUT_KEY_UP:
		glMatrixMode(GL_MODELVIEW);
		glTranslated(0, 1, 0);
		display();
		break;
	case GLUT_KEY_DOWN:
		glMatrixMode(GL_MODELVIEW);
		glTranslated(0, -1, 0);
		display();
		break;
	case GLUT_KEY_RIGHT:
		glMatrixMode(GL_MODELVIEW);
		glTranslated(1, 0, 0);
		display();
		break;
	case GLUT_KEY_LEFT:
		glMatrixMode(GL_MODELVIEW);
		glTranslated(-1, 0, 0);
		display();
		break;

	case GLUT_KEY_HOME:
		glMatrixMode(GL_MODELVIEW);
		glRotatef(90,0, 0, 1);
		display();
		break;
	case GLUT_KEY_END:
		glMatrixMode(GL_MODELVIEW);
		glRotatef(90, 0, 0, -1);
		display();
		break;
	case GLUT_KEY_PAGE_UP:
		glMatrixMode(GL_MODELVIEW);
		glRotatef(10, 1, 1, -1);
		display();
		break;
	case GLUT_KEY_PAGE_DOWN:
		glMatrixMode(GL_MODELVIEW);
		glRotatef(10, -1, -1, 1);
		display();
		break;
}
}

void drawXYZ() {
	glBegin(GL_LINES); 
	glColor3f(1, 0, 0); 
	glVertex3f(-800, 0, 0); 
	glVertex3f(800, 0, 0);//X 
	glColor3f(0,1,0); 
	glVertex3f(0,-800,0); 
	glVertex3f(0,800,0);//Y 
	glColor3f(0,0, 800); 
	glVertex3f(0,0,0); 
	glVertex3f(0,0,800);//Z 
	glEnd();
}
