package com.example.maksim_zakharenka.ros_l2;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    private static final String MINUS = "-";
    private static final String PLUS = "+";
    private static final String MULTIPLY = "*";
    private static final String DIVIDE = "/";
    private static final String ERR = "err";

    private EditText mValueFirstTop;
    private EditText mValueSecondTop;
    private EditText mValueFirstBottom;
    private EditText mValueSecondBottom;
    private EditText mValueResultTop;
    private EditText mValueResultBottom;
    private EditText mMathematicalSymbol;

    @Override
    public void onClick(final View v) {
        switch (v.getId()) {
            case R.id.clear_button:
                clearAllEditText();

                break;
            case R.id.calculate_button:
                startCalculate();

                break;
            default:
                break;
        }
    }

    @Override
    protected void onCreate(final Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        initView();
    }

    private void clearEditText(final EditText pEditText) {
        pEditText.setText(null);
    }

    private void clearAllEditText() {
        clearEditText(mValueFirstTop);
        clearEditText(mValueSecondTop);
        clearEditText(mValueFirstBottom);
        clearEditText(mValueSecondBottom);
        clearEditText(mValueResultTop);
        clearEditText(mValueResultBottom);
        clearEditText(mMathematicalSymbol);
    }

    private void startCalculate() {
        final String x1 = mValueFirstTop.getText().toString();
        final String x2 = mValueFirstBottom.getText().toString();
        final String y1 = mValueSecondTop.getText().toString();
        final String y2 = mValueSecondBottom.getText().toString();
        final String mathematicalSymbol = mMathematicalSymbol.getText().toString();

        if (!x1.isEmpty() && !x2.isEmpty() && !y1.isEmpty() && !y2.isEmpty() && !mathematicalSymbol.isEmpty()) {
            calculate(string2double(x1), string2double(x2), string2double(y1), string2double(y2), mathematicalSymbol);
        } else {
            Toast.makeText(this, "Please, fill all fields and try again.", Toast.LENGTH_LONG).show();
        }
    }

    private double string2double(final String str) {
        return Double.parseDouble(str);
    }

    private String double2string(final double dbl) {
        return String.valueOf(dbl);
    }

    private String getValue(final double x, final double y, final String mathematicalSymbol) {
        switch (mathematicalSymbol) {
            case MINUS:
                return double2string(x - y);
            case PLUS:
                return double2string(x + y);
            case MULTIPLY:
                return double2string(x * y);
            case DIVIDE:
                return double2string(x / y);
            default:
                return ERR;
        }
    }

    private void calculate(final double x1, final double x2, final double y1, final double y2, final String mathematicalSymbol) {
        if (!mathematicalSymbol.equals(DIVIDE)) {
            mValueResultTop.setText(getValue(x1, y1, mathematicalSymbol));
            mValueResultBottom.setText(getValue(x2, y2, mathematicalSymbol));
        } else {
            mValueResultTop.setText(getValue(x1, y2, MULTIPLY));
            mValueResultBottom.setText(getValue(x2, y1, MULTIPLY));
        }
    }

    private void initView() {
        findViewById(R.id.clear_button).setOnClickListener(this);
        findViewById(R.id.calculate_button).setOnClickListener(this);

        mValueFirstTop = (EditText) findViewById(R.id.value_first_top);
        mValueSecondTop = (EditText) findViewById(R.id.value_second_top);
        mValueFirstBottom = (EditText) findViewById(R.id.value_first_bottom);
        mValueSecondBottom = (EditText) findViewById(R.id.value_second_bottom);
        mValueResultTop = (EditText) findViewById(R.id.value_result_top);
        mValueResultBottom = (EditText) findViewById(R.id.value_result_bottom);
        mMathematicalSymbol = (EditText) findViewById(R.id.mathematical_symbol);
    }
}
