
======[[ EnemyAI ]]===============================================================================

敵（エネミー）を作成・追加する場合は以下の手順を行うこと


　１　．「EnemyStateMachine」をアタッチする

２−１．「EnemyStateFunction」を継承したスクリプトでプログラムを書く

２−２．　上記継承したスクリプトをアタッチする

　３　．「EnemyStateMachine」の
		「Vigilance（索敵状態）、PlayerFind（プレイヤ発見状態）、Die（死亡状態）」
		　それぞれにアタッチした継承スクリプトを参照させる。

　４　.　敵の体力や死亡時の効果音、エフェクト、獲得スコアなどの情報を入力する


（５）．オブジェクトのPrefab化を行い、
		ヒエラルキーウィンドウの「GameManagement」の「EnemyCreate」もしくは「BossCreate」に
		Prefabを挿入してゲーム内で生成（複製）できるようにする。

==================================================================================================