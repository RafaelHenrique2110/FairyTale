using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_movimentacaoPlayer
{
    Vector3 Movimentacao(Transform dir, float speed, Animator anin);

}
