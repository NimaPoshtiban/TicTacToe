
extern "C" {
    #include "tictactoeai.h"
	__declspec(dllexport)int** answer_as_o(int** plate) {
		return answer(plate);
	};
}