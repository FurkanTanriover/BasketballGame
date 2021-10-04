# BasketballGame
 
- Projede singleton, observer, object pool, scriptable object tasarım kalıpları uygulanmıştır.
- Level dataları (top tipi, top başlangıç noktası, topa uygulanan güç ve top adeti) scriptable object ile hazırlanmıştır.
- Kullanılan top tipleri (rengi, büyüklüğü, ağırlığı) scriptable object ile hazırlanmıştır.
- UIManager, GameManager ve LevelController singleton olacak şekilde ayarlanmıştır.
- Atış yapıldıktan sonra top oluşturulması için object pool kullanılmıştır.
- Level bitişinde, atış yapıldıktan sonra, top adetinin azaltılmasında, skor tetiklenmesinde ve yeni level geçişinde eventler kullanılmıştır.
- Level sonu için particle system ile konfeti efekti oluşturulmuştur.
- 10 levelden sonra tekrar başa sarmaktadır.
